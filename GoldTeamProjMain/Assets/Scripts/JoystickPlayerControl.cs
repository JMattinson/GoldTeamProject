using UnityEngine;
using UnityEngine.Events;

public class JoystickPlayerControl : MonoBehaviour
{
    public FloatData speed;
    public float rotateSpeed;
    public bool isIdleAnimStart;

    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public UnityEvent RunTrueEvent,StopEvent;

    public void FixedUpdate()
    {
        //Whoever coded Unity's new input system should be tried as a warcriminal.
        Vector3 movementDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * (speed.value * Time.deltaTime),Space.World);

        if (movementDirection != Vector3.zero)
        {
            isIdleAnimStart = true;
            RunTrueEvent.Invoke();
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,rotateSpeed * Time.deltaTime);
        }
        else if (movementDirection == Vector3.zero && isIdleAnimStart)
        {
            isIdleAnimStart = false;
            StopEvent.Invoke();
        }
        
        }
}