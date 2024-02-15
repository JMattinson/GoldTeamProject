
using UnityEngine;

public class GameActionInvokerBehavior : MonoBehaviour
{

    public GameAction targetAction;
    // extremely simple code to invoke a gameaction. mostly making this so I can call it in animations
    public void InvokeGameAction()
    {
        targetAction.RaiseAction();
        print("Calling"+targetAction);
    }
     
}
