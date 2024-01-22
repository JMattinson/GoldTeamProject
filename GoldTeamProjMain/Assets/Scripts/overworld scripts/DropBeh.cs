using UnityEngine;
using UnityEngine.Events;

public class DropBeh : MonoBehaviour
{
    public UnityEvent death;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//dont execute for everything
        {
            Debug.Log(other);
            //id like to add code here later to allow it to float towards the player
            death.Invoke();//use the event to add to the plr inventory
            Destroy(this);
        }
    }
}
