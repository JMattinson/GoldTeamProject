using UnityEngine;



public class IncrementalAnimationManager : MonoBehaviour
{
    private Animator targetAnimator;
    public string parameterName;
    public int combo;
    public int maxCombo;
    
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void IncrementAnim()
    {
        if (combo < maxCombo)
        {
            combo = targetAnimator.GetInteger(parameterName);
            combo++;
            targetAnimator.SetInteger(parameterName,combo);
            
        }
        
        
    }
    
    public void DeincrementAnim()
    {

        if (combo > 0 )
        {
            combo = targetAnimator.GetInteger(parameterName);
            combo--;
            targetAnimator.SetInteger(parameterName,combo);
            
            
            
            
        }
        
        
        
    }
    public void ResetAnim()
    {
        combo = 0; 
        
        targetAnimator.SetInteger(parameterName,0);
    }
}
