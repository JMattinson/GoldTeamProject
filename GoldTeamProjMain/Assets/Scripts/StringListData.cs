using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class StringListObject : ScriptableObject
{
    public List<string> value;
    public string currentValue;

    public void UseNextValue()
    {
        currentValue = value[0];
    }
}
