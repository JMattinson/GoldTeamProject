using UnityEngine;

public class InputCheckBehavior : MonoBehaviour
{
    public BoolData isActionPressed;
    public string paramName;
    public bool startPositon;

    private Animator targetAnimator;
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
        isActionPressed.value = startPositon;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActionPressed.value)
        {
            targetAnimator.SetTrigger(paramName);
            debug.log("nonsesnse")
            
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
