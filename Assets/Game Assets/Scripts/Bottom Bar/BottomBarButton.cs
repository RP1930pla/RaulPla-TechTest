using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class BottomBarButton : MonoBehaviour
{
    bool buttonEnabled = false;
    public bool locked = false;

    public BottomBarView buttonController;
    public RectTransform rectTransform;
    public RectTransform childRectTransform;
    public AnimationCurve fadeCurve;

    public Image image;

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        childRectTransform.GetComponentInChildren<RectTransform>();
        image.GetComponent<Image>();

        if (buttonController != null)
        {
            buttonController.Subscribe(this);
        }
    }

    private void OnDisable()
    {
        if (buttonController != null)
        {
            buttonController.Unsubscribe(this);
        }
    }

    public void SwapStates() 
    {
        if (buttonEnabled)
        {
            CloseButton();
        }
        else 
        {
            OpenButton();
        }
    }

    public void CloseButton() 
    {
        buttonEnabled = false;
        rectTransform.DOSizeDelta(new Vector2(0f, 667.457f), 0.3f);
        childRectTransform.DOLocalMoveY(0f, 0.3f);
        image.DOFade(0, 0.3f).SetEase(fadeCurve);

    }

    public void OpenButton() 
    {
        if (locked == false)
        {
            buttonController.CloseOtherEnabledButtons();
            buttonEnabled = true;

            //Do Tweening Stuff
            rectTransform.DOSizeDelta(new Vector2(946.8f, 667.457f), 0.3f);
            childRectTransform.DOLocalMoveY(190.49f, 0.3f);
            image.DOFade(1, 0.3f).SetEase(fadeCurve);
            //

            buttonController.ContentActivated();

        }

    }

    
}
