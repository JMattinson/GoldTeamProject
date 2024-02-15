using UnityEngine;

public class MovementAnimManager: MonoBehaviour
{
    private Animator targetAnimator;
    public string parameterName;
    public int WalkSpeed;
    public int MaxWalkSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void WalkAnim()
    {
        if (WalkSpeed < MaxWalkSpeed)
        {
            WalkSpeed = targetAnimator.GetInteger(parameterName);
            WalkSpeed++;
            targetAnimator.SetInteger(parameterName,WalkSpeed);
            
        }
        
        
    }
    
    public void IdleAnim()
    {

        if (WalkSpeed > 0 )
        {
            WalkSpeed = targetAnimator.GetInteger(parameterName);
            WalkSpeed--;
            targetAnimator.SetInteger(parameterName,WalkSpeed);
            
            
            
            
        }
        
        
        
    }
    public void ResetAnim()
    {
        WalkSpeed = 0; 
        
        targetAnimator.SetInteger(parameterName,0);
    }
}
