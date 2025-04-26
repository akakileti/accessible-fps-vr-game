using UnityEngine;
using Riptide;
using Riptide.Utils;

public class NetworkManager : MonoBehaviour
{
    [SerializeField] private ushort gamePort; // port that server and client communicate over
    private Server server;

    private void Awake()
    {
        if (server == null)
        {
            CreateServer();
        }
    }

    private void FixedUpdate()
    {
        server.Update();
    }

    private void ControllerConnected(object sender, ServerConnectedEventArgs e)
    {
        // sends message to client indicating successful connection
        // TODO: fix hardcoding of message id
        Message successMessage = Message.Create(MessageSendMode.Unreliable, 7);
        server.SendToAll(successMessage);
    }

    private void ControllerDisconnected(object sender, ServerDisconnectedEventArgs e)
    {
        Debug.Log("Controller Disconnected");
    }

    private void CreateServer()
    {
        // initialize riptide
#if UNITY_EDITOR
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
#else
            Application.SetStackTraceLogType(UnityEngine.LogType.Log, StackTraceLogType.None);
            RiptideLogger.Initialize(Debug.Log, true);
#endif

        // start new server
        server = new Server();
        server.Start(gamePort, 2);

        // assign callbacks
        server.ClientConnected += ControllerConnected;
        server.ClientDisconnected += ControllerDisconnected;

    }
     

}
