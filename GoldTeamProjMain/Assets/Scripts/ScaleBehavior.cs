
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class ScaleBehavior : MonoBehaviour
{
    public Transform scaleObj;
    public FloatData maxScale;

    Vector3 scaleChange = new Vector3(1.0f, 1.0f, 1.0f);
    void Start()
    {
        scaleObj = GetComponent<Transform>();
    }

    public void ChangeScale(FloatData currentScale)
    {
        if (currentScale.value > 0)
        {
            scaleChange.z = (currentScale.value/maxScale.value);
            scaleObj.transform.localScale = (scaleChange);
        }
    }
}
