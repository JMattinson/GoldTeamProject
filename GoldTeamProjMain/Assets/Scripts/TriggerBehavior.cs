using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent triggerStartEvent, triggerEndEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerStartEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerEndEvent.Invoke();
    }
}
