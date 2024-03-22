using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackBehavior : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public void KnockBack()
    {
        print("Knockback activated");
        rb.AddForce(transform.forward * -300);
    }
}
