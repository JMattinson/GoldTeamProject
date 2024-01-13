//This code enables the creation of IntData files

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    private int startingValue;
    public UnityEvent onMinEvent, onMaxEvent;
    
    private void Start()
    {
        startingValue = value;
    }
    public void SetValue(int num)
    {
        value = num;
    }

    public void CompareValue(IntData obj)
    {
        if (value >= obj.value)
        {
         
        }
        else
        {
            value = obj.value;
        }

    }
    public void SetValue(IntData obj)
    {
        value = obj.value;
    }  
   
    public void UpdateValue(int num)
    {
    
        value += num;
    }
    public void UpdateValue(IntData num)
    {
    
        value += num.value;
    }
    
    public void CheckMin(int num)
    {
        if (value <= num)
        {
            value = num;
            onMinEvent.Invoke();
        }
    }
    
    public void CheckMin(IntData num)
    {
        if (value <= num.value)
        {
            value = num.value;
            onMinEvent.Invoke();
        }
    }

    public void CheckMax(int num)
    {
        if (value >= num)
        {
            value = num;
            onMaxEvent.Invoke();
        }
    }
    public void CheckMax(IntData num)
    {
        if (value >= num.value)
        {
            value = num.value;
            onMaxEvent.Invoke();
        }
    }
    public void ResetValue()
    {
        value = startingValue;
    }
    
}