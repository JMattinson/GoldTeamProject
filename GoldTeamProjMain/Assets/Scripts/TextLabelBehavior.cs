using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLabelBehavior : MonoBehaviour
{
    private TextMeshProUGUI label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateText(StringListObject obj)
    {
        label.text = obj.currentValue;
    }
}