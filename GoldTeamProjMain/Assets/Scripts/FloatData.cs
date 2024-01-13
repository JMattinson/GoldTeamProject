//This code enables the creation of Float files
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
  
    public float value;
    private float startingValue;
    public UnityEvent onMinEvent, onMaxEvent;

    private void Start()
    {
        startingValue = value;
    }
    public void SetValue(float num)
    {
        value = num;
    }
    
    public void SetValue(FloatData num)
    {
        value = num.value;
    }
    
    public void UpdateValue(FloatData num)
    {
        value += num.value;
    }
    
    public void UpdateValue(float num)
    {
    
        value += num;
        
    }

    public void CheckMin(float num)
    {
        if (value <= num)
        {
            value = num;
            onMinEvent.Invoke();
        }
    }
    
    public void CheckMin(FloatData num)
    {
        if (value <= num.value)
        {
            value = num.value;
            onMinEvent.Invoke();
        }
    }

    public void CheckMax(float num)
    {
        if (value >= num)
        {
            value = num;
            onMaxEvent.Invoke();
        }
    }
    public void CheckMax(FloatData num)
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