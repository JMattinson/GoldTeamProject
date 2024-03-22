using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent triggerStartEvent, triggerEndEvent,playerEvent, weaponEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerStartEvent.Invoke();
        //i hope you dont mind me adding these it just checks what it is being hit by
        print("collision");
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
