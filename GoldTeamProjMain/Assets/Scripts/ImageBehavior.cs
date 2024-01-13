using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehavior : MonoBehaviour
{
    //OK this isn't too complicated, you essentially assign an image to be the healthbar, then tell unity to update it's fill amount based on the missing health percent.
    public UnityEvent startEvent;

    private Image imageObj; //this is your healthbar.it'll need to be attached to an image in a screenspace canvas for persistent UI, or a worldspace canvas to float above enemies/objects.
    //You can toggle between bar and radial health on the image object itself.
    public FloatData maxHealth; //right now this reads a float Scriptable object, but you could probably change it to just a float if you felt like it.
    
    
    
    void Start()
    {
        imageObj = GetComponent<Image>();
        startEvent.Invoke();// this just opens up an in-editor start event. it's not necessary for the code,but it's here if you want to do anything.
    }

    
    public void UpdateImage(FloatData data) //this is the main part of the code, you'll want to call this method every time you want the health bar to update, after you've already added/subtracted health. I usually call on it using either a unity event or a game action object.
    {
        imageObj.fillAmount = (data.value / maxHealth.value);

    }
}
