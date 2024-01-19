using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent triggerStartEvent, triggerEndEvent,playerEvent, weaponEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerStartEvent.Invoke();
        if (other.CompareTag("Player"))
        {
            playerEvent.Invoke();
        }

        if (other.CompareTag("Weapon"))
        {
            weaponEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerEndEvent.Invoke();
    }
}
