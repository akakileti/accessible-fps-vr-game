using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPickup : MonoBehaviour
{

    private InputDevice rightXRController;

    [SerializeField] private XRGrabInteractable gunObj;
    [SerializeField] private XRInteractionManager interactionManager;
    [SerializeField] private XRBaseInteractor interactor;

    void Start()
    {
        // Get right and left controllers
        List<InputDevice> devices = new List<InputDevice>();

        // Defines list of characteristics to select the input device by (for a right-handed controller)
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.HeldInHand & InputDeviceCharacteristics.Right;
        // Gets all devices that meet the above characteristics and places them in the list devices
        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        // Ensures we have found at least one suitable controller before assigning them
        if (devices.Count > 0)
        {
            rightXRController = devices[2]; // attached to right controller
        }
        else
            Debug.LogError("All input devices checked; no left or right-handed controllers found.");
    }

    private void Update()
    {
        if (rightXRController.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue || Input.GetKeyDown("space"))
        {
            if (!RemoteController.isGunHeld)
            {
                interactionManager.SelectEnter((IXRSelectInteractor) interactor, (IXRSelectInteractable) gunObj);
            }
        }

    }
}
