using UnityEngine;
using Riptide;

public class RemoteController : MonoBehaviour
{

    public enum MessageTypes
    {
        Shoot = 1,
        TurnRight = 2,
        TurnLeft = 3,
        TurnUp = 4,
        TurnDown = 5,
        Move = 6
    }

    // if player is holding gun, used in determing whether to shoot on shoot command
    public static bool isGunHeld { get; set; }

    // gun script
    static SimpleShoot ss;

    // references to player and player components
    static GameObject playerObj;
    static GameObject headObj;
    static CharacterController characterController;

    // used for moving the player
    private static bool moving;
    private static Vector3 movementDirection;
    [SerializeField] private static float speed = 2f;

    private void Awake()
    {
        // set attributes
        ss = GameObject.Find("Handgun_Black").GetComponentInChildren<SimpleShoot>();
        playerObj = GameObject.Find("PlayerObj");
        headObj = GameObject.Find("Main Camera");
        characterController = playerObj.GetComponent<CharacterController>();
    }

    private void Update()
    {

        // moves player in movement direction if the player should be moving
        if (moving)
        {
            Vector3 frontDirection = headObj.transform.forward;
            Vector3 rightDirection = headObj.transform.right;

            Vector3 localMovement = frontDirection * movementDirection.z + rightDirection * movementDirection.x;
            Vector3 globalMovement = transform.TransformVector(localMovement);
            globalMovement.y = 0;
            globalMovement.Normalize();

            characterController.Move(globalMovement * Time.deltaTime * speed);

            // characterController.Move(movementDirection * Time.deltaTime * speed);

        }
    }

    #region message handlers

    // shoots the gun
    [MessageHandler((ushort) MessageTypes.Shoot)]
    private static void HandleShootMessage(ushort id, Message message)
    {
        if (ss != null && isGunHeld)
        {
            ss.pullTheTrigger();
        }
    }

    // turns the player right
    [MessageHandler((ushort) MessageTypes.TurnRight)]
    private static void HandleTurnRight(ushort id, Message message)
    {
        Vector3 rotation = new Vector3(0, 45, 0);
        playerObj.transform.Rotate(rotation);
    }

    // turns the palyer left
    [MessageHandler((ushort) MessageTypes.TurnLeft)]
    private static void HandleTurnLeft(ushort id, Message message)
    {
        Vector3 rotation = new Vector3(0, -45, 0);
        playerObj.transform.Rotate(rotation);
    }

    // tilt players view up, does not work
    [MessageHandler((ushort) MessageTypes.TurnUp)]
    private static void HandleTurnUp(ushort id, Message message)
    {
        Vector3 rotation = new Vector3(-30, 0, 0);
        headObj.transform.Rotate(rotation);
    }

    // tilt players view down, does not work
    [MessageHandler((ushort) MessageTypes.TurnDown)]
    private static void HandleTurnDown(ushort id, Message message)
    {
        Vector3 rotation = new Vector3(30, 0, 0);
        headObj.transform.Rotate(rotation);
    }

    // sets the movement direction
    [MessageHandler((ushort)MessageTypes.Move)]
    private static void HandleMove(ushort id, Message message)
    {
        float x = message.GetFloat();
        float z = message.GetFloat();

        if (x != 0 && z != 0){
            movementDirection = new Vector3(x, 0, z);
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
    #endregion
}
