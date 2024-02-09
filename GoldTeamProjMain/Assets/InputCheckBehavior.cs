using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheckBehavior : MonoBehaviour
{
    public BoolData isActionPressed;

    private Animator targetAnimator;
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActionPressed.value)
        {
            targetAnimator.SetTrigger("idle");
        }
            
        
    }

    public void ToggleOn()
    {
        
        isActionPressed.value = true;
    }
    
    public void ToggleOff()
    {
        isActionPressed.value = false;
        
    }
 
}
