using UnityEngine;
using Lean.Touch;

public class DetectDrag : MonoBehaviour
{
    private LeanFinger finger;
    private Vector2 direction;

    [SerializeField] PlayerController playerController;

    public void FingerDetected(LeanFinger finger)
    {
        if (this.finger == null)
        {
            this.finger = finger;
        }
    }

    private void FixedUpdate()
    {
        if (this.finger != null && !this.finger.Set)
        {
            // if a finger is no longer touching the screen, stop the drag
            this.finger = null;
            playerController.DragStop();
        }

        if (this.finger != null && this.finger.Old)
        {
            // if the finger has exceeded the tap threshold, it is a drag
            // calculate the drag direction and send to server.
            Vector2 detectedDirection = (this.finger.ScreenPosition - this.finger.StartScreenPosition);
            detectedDirection.Normalize();

            if ((this.direction - detectedDirection).magnitude > 0.01)
            {
                // only send a new direction if the direction is significantly different
                Debug.Log("New direction detected");
                this.direction = detectedDirection;
                playerController.Drag(detectedDirection);
            }
        }

    }
}
