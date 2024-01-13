
using System;
using UnityEngine;

public class BilboardBehavior : MonoBehaviour
{
    public Camera focusCam;

    private void Start()
    {
        focusCam = GameObject.Find("MainCamera").GetComponent<Camera>();

    }

    public void Billboard()
    {
        transform.LookAt(focusCam.transform.position, -Vector3.up);
        
    }

    
}
