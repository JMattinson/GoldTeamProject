
using UnityEngine;
using UnityEngine.Events;

public class StartAction : MonoBehaviour
{
    public UnityEvent startEvent;
    void Start()
    {
        startEvent.Invoke();
    }

}
