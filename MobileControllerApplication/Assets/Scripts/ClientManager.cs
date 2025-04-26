using UnityEngine;
using Riptide.Utils;
using Riptide;
using UnityEngine.UI;

/**
 * This script is intended to manage all client side networking behavior.
 * This includes creating the new client instance, finding and connecting to the server,
 * and sending messages to the server.
 */
public class ClientManager : MonoBehaviour
{
    public enum MessageTypes
    {
        Shoot = 1,
        TurnRight = 2,
        TurnLeft = 3,
        TurnUp = 4,
        TurnDown = 5,
        Move = 6,
        ConnectionSuccessful = 7,
    }

    // networking stuffs
    [SerializeField] public static string serverIpAddress;
    [SerializeField] private ushort gamePort;
    private Client client;

    // visual indicator of connection
    public static Image wifiTestingImage;

    private void Awake()
    {
        wifiTestingImage = GameObject.Find("wifiBackground").GetComponent<Image>();
        wifiTestingImage.color = Color.red;

        // initialize riptide and instantiate a new client
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
        client = new Client();

        client.ConnectionFailed += AttemptConnectionAgain;

        serverIpAddress.Trim();
        string trimmedIp = serverIpAddress.Substring(0, serverIpAddress.Length - 1);
        serverIpAddress = trimmedIp;
        client.Connect(string.Format("{0}:{1}", trimmedIp, gamePort));

    }

    private void FixedUpdate()
    {
        client.Update();
    }

    public void AttemptConnectionAgain(object sender, ConnectionFailedEventArgs e)
    {
        client.Connect(string.Format("{0}:{1}", serverIpAddress, gamePort));
    }
    #region messaging

    // receive message from server indicating successful connection
    [MessageHandler((ushort)MessageTypes.ConnectionSuccessful)]
    private static void ConnectionSuccessful(ushort id, Message message)
    {
        wifiTestingImage.color = Color.green;
    }

    // sends a udp packet with only a message type and no data
    public void SendUnreliableMessage(ushort messageType)
    {
        Message message = Message.Create(MessageSendMode.Unreliable, messageType);
        client.Send(message);
    }

    // sends a udp packet with a message type and 2 floats
    public void SendVector2(ushort messageType, float x, float y)
    {
        Message message = Message.Create(MessageSendMode.Unreliable, messageType);
        message.AddFloat(x);
        message.AddFloat(y);
        client.Send(message);
    }
    #endregion
}
