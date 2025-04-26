using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class AccessibleMenu : MonoBehaviour
{

    [SerializeField] Menu menuScript;
    private bool action;

    public void StartSelectionTimer(HoverEnterEventArgs e)
    {
        GameObject button = e.interactableObject.transform.gameObject;

        if (button.name == "Play")
        {
            action = true;
        }
        else if (button.name == "Quit")
        {
            action = false;
        }

        StartCoroutine("SelectionTimer");
    }

    public void StopSelectionTimer(HoverExitEventArgs e)
    {
        StopCoroutine("SelectionTimer");
    }

    public IEnumerator SelectionTimer()
    {
        yield return new WaitForSecondsRealtime(.5f);

        MakeSelection();
    }

    public void MakeSelection()
    {
        if (action)
        {
            menuScript.StartGame();
        }
        else if (action == false)
        {
            menuScript.Quit();
        }
    }
}
