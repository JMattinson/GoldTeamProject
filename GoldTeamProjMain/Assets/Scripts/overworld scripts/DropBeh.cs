using UnityEngine;
using UnityEngine.Events;

public class DropBeh : MonoBehaviour
{
    public UnityEvent death;
    public GameObject parent;
     public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//dont execute for everything
        {
            //id like to add code here later to allow it to float towards the player
            death.Invoke();//use the event to add to the plr inventory
            Destroy(parent);
        }
    }

}
