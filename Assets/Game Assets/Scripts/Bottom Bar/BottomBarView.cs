using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottomBarView : MonoBehaviour
{

    public List<BottomBarButton> buttons;
    bool isHidden = false;

    [SerializeField]
    RectTransform buttonBarRectTrans;
    [SerializeField]
    AnimationCurve animationCurve;

    public Vector2 minMaxYPos = new Vector2(-679, -50);
    public float time = 0.4f;

    void Closed() 
    {
        Debug.Log("Event: Closed");
    }

    public bool IsSomethingSelected() 
    {
        if (buttons != null) 
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].buttonEnabled)
                {
                    return true;
                }
            }
            return false;
        }
        else 
        {
            return false;
        }

    }

    public void CheckForNoContent() 
    {
        if (IsSomethingSelected() == false)
        {
            Closed();
        }
    }

    private void Start()
    {
        CheckForNoContent();
    }

    public void ContentActivated() 
    {
        Debug.Log("Event: Content Activated");
    }

    public void Subscribe(BottomBarButton button)
    {
        if (buttons == null) 
        {
            buttons = new List<BottomBarButton>();
        }

        buttons.Add(button);
    }

    public void Unsubscribe(BottomBarButton button) 
    {
        if (buttons == null)
        {
            buttons = new List<BottomBarButton>();
        }

        buttons.Remove(button);
    }

    public void CloseOtherEnabledButtons(bool silent) 
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonEnabled) 
            {
                buttons[i].CloseButton(silent);
            }
        }
    }

    public void HideFooter() 
    {
        if (isHidden == false)
        {
            buttonBarRectTrans.DOAnchorPosY(minMaxYPos.x, time).SetEase(animationCurve);
            CloseOtherEnabledButtons(false);
            isHidden = true;
        }
        else 
        {
            buttonBarRectTrans.DOAnchorPosY(minMaxYPos.y, time).SetEase(animationCurve);
            isHidden = false;
        }
    }

}
