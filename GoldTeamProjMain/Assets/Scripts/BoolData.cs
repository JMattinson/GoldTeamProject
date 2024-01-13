//This code enables the creation of BoolData files
using UnityEngine;
[CreateAssetMenu]
public class BoolData : ScriptableObject
{
  
    public bool value;
    public void SetValue(bool checque)
    {
        value = checque;
    }
}