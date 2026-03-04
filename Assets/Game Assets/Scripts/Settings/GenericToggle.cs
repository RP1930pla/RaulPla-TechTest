using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GenericToggle : MonoBehaviour
{
    public Image background;
    public RectTransform dot;

    public Color deactivatedColor;
    public Color activeColor;

    public float stateTimeTransition = 0.3f;

    public void TweenBasedOnState(bool state) 
    {
        //Debug.Log(state);
        if (state == true)
        {
            background.DOColor(deactivatedColor, stateTimeTransition);
            dot.DOAnchorPos(new Vector2(0f, 5.499924f), stateTimeTransition);
        }
        else 
        {
            background.DOColor(activeColor, stateTimeTransition);
            dot.DOAnchorPos(new Vector2(-194f, 5.499924f), stateTimeTransition);
        }
    }
}
