using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public bool CanRun { get; set; }
    public UnityEvent AwakeEvent, startEvent,startCountEvent, repeatCountEvent, endCountEvent,repeatUntilFalseEvent;
    public IntData counterNum;
    public FloatData TicRate;
    
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;

    public void Awake()
    {
        wfsObj = new WaitForSeconds(TicRate.value);
        wffuObj = new WaitForFixedUpdate();
        startEvent.Invoke();
    }

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    
    private IEnumerator Counting()
    {
        

        
        startCountEvent.Invoke();
        yield return wfsObj;
        while (counterNum.value > 0)
        {
            repeatCountEvent.Invoke();
            counterNum.value--;
            yield return wfsObj;

        }
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        CanRun = true;
        StartCoroutine(RepeatUntilFalse());
    }
    private IEnumerator RepeatUntilFalse()
    {
        while (CanRun)
        {
            yield return wfsObj;
            repeatUntilFalseEvent.Invoke();
        }
    }
}
