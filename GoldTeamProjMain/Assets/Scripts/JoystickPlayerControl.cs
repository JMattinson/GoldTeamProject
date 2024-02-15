using System;
using UnityEngine;
using UnityEngine.Events;

public class JoystickPlayerControl : MonoBehaviour
{
    public FloatData speed;
    public float rotateSpeed;
    private float rotateMod;
    public bool isIdleAnimStart;

    private bool canPlayerMove;

    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public UnityEvent RunTrueEvent,StopEvent;

    private void Start()
    {
        canPlayerMove = true;
    }

    public void FixedUpdate()
    {
        //Whoever coded Unity's new input system should be tried as a warcriminal.
        Vector3 movementDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        movementDirection.Normalize();
        
            transform.Translate(movementDirection * (speed.value * Time.deltaTime * (Convert.ToInt32(canPlayerMove)) ),Space.World);
        

        if (movementDirection != Vector3.zero)
        {
            rotateMod = (0.25f + (0.75f * Convert.ToSingle(canPlayerMove)));
            isIdleAnimStart = true;
            RunTrueEvent.Invoke();
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,(rotateSpeed * rotateMod) * Time.deltaTime);
        }
        else if (movementDirection == Vector3.zero && isIdleAnimStart)
        {
            isIdleAnimStart = false;
            StopEvent.Invoke();
            print("Stopped!");
        }
        
        }

    public void CallToggleMovementOn()
    {
        canPlayerMove = true;
    }
    public void CallToggleMovementOff()
    {
        canPlayerMove = false;
    }
}