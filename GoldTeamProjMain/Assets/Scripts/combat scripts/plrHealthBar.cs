using UnityEngine;

public class plrHealthBar : MonoBehaviour
{
    public RectTransform valImg;
    public int maxVal;

    private RectTransform rectangle;
    private void Start()
    {
        rectangle = GetComponent<RectTransform>();
    }

    public void maxChange()  //upgrades the viz to match the stats
    {
        Vector2 pos = rectangle.anchoredPosition;
        Vector2 size = rectangle.sizeDelta;
        pos.x=((maxVal/2)+10);
        size.x = maxVal;
        rectangle.anchoredPosition = pos;
        rectangle.sizeDelta = size;
    }

    public void updateVal(int currentVal)//updates the healthy image to shrink
    {
        Vector2 rect = valImg.sizeDelta;
        rect.x=((maxVal - currentVal)*(-1/maxVal));
        valImg.sizeDelta = rect;
    }
}
