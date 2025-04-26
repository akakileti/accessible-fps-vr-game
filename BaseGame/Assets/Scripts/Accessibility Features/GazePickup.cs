using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GazePickup : MonoBehaviour
{

    [SerializeField] private XRGrabInteractable gunObj;
    [SerializeField] private XRInteractionManager interactionManager;
    [SerializeField] private XRBaseInteractor interactor;

    public void StartPickupTimer()
    {
        StartCoroutine("PickupTimer");
    }

    public void StopPickupTimer()
    {
        StopCoroutine("PickupTimer");
    }

    public IEnumerator PickupTimer()
    {
        yield return new WaitForSecondsRealtime(.5f);

        Pickup();
    }

    public void Pickup()
    {
        interactionManager.SelectEnter((IXRSelectInteractor) interactor, (IXRSelectInteractable) gunObj);
    }
}
