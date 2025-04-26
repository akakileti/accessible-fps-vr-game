using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverToSelect : MonoBehaviour
{
    [SerializeField] Menu menu;

    [SerializeField] GameObject[] buttons;

    private void Awake()
    {
        foreach (var button in buttons)
        {
            var trigger = button.AddComponent<EventTrigger>();
            var e = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
            e.callback.AddListener(Hover);
            trigger.triggers.Add(e);

            var e2 = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
            e2.callback.AddListener(Exit);
            trigger.triggers.Add(e2);
        }
    }

    private void Hover(BaseEventData arg0)
    {
        StartCoroutine(HoverEntered());
    }

    private IEnumerator HoverEntered()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        menu.StartGame();
    }

    private void Exit(BaseEventData arg0)
    {
        StopCoroutine(HoverEntered());
    }
}
