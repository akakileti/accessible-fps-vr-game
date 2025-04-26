using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public enum Controls
    {
        Tap = ClientManager.MessageTypes.Shoot,
        RightSwipe = ClientManager.MessageTypes.TurnRight,
        LeftSwipe = ClientManager.MessageTypes.TurnLeft,
        UpSwipe = ClientManager.MessageTypes.TurnUp,
        DownSwipe = ClientManager.MessageTypes.TurnDown,
        Drag = ClientManager.MessageTypes.Move
    }

    // for communicating to server
    [SerializeField] ClientManager ClientManager;

    // used for testing/verification
    [SerializeField] bool isDebugMode;
    [SerializeField] Image testingImage;
    [SerializeField] TextMeshProUGUI testingText;

    private void Awake()
    {
        if (!isDebugMode)
        {
            // set debug/testing indicators to inactive
            testingImage.gameObject.SetActive(false);
            testingText.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void Swipe(Vector2 swipe)
    {
        // sends swipe direction
        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            if (swipe.x > 0)
            {
                ClientManager.SendUnreliableMessage((ushort) Controls.RightSwipe);
                if (isDebugMode)
                {
                    testingImage.color = Color.red;
                }
            }

            else if (swipe.x < 0)
            {
                ClientManager.SendUnreliableMessage((ushort)Controls.LeftSwipe);
                if (isDebugMode)
                {
                    testingImage.color = Color.green;
                }
            }
        }
        else
        {
            if (swipe.y > 0)
            {
                ClientManager.SendUnreliableMessage((ushort)Controls.UpSwipe);
                if (isDebugMode)
                {
                    testingImage.color = Color.yellow;
                }
            }
            else if (swipe.y < 0)
            {
                ClientManager.SendUnreliableMessage((ushort)Controls.DownSwipe);
                if (isDebugMode)
                {
                    testingImage.color = Color.blue;
                }
            }
        }
    }

    public void SingleTap()
    {
        ClientManager.SendUnreliableMessage((ushort)Controls.Tap);
        if (isDebugMode)
        {
            testingImage.color = Color.gray;
        }
    }

    public void Drag(Vector2 drag)
    {
        // sends drag vector
        ClientManager.SendVector2((ushort) Controls.Drag, drag.x, drag.y);
        if (isDebugMode)
        {
            testingText.text = string.Format("{0:f2}\n{1:f2}", drag.x, drag.y);
        }
    }

    public void DragStop()
    {
        // indicates drag stops
        ClientManager.SendVector2((ushort)Controls.Drag, 0, 0);
        if (isDebugMode)
        {
            testingText.text = "0\n0";
        }
    }
}
