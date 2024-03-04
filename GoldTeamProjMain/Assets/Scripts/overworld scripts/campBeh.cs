using System.Collections.Generic;
using UnityEngine;

public class campBeh : MonoBehaviour
{
    public List<gruntEneBeh> babies;//why did i call it that?
    
    private int looping;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looping = 0;
            foreach (var item in babies)
            {
                babies[looping].attack();
                looping++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looping = 0;
            foreach (var item in babies)
            {
                babies[looping].goHome();
            }
        }
    }
}
