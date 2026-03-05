using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public GameObject uiSettings;
    public RectTransform uiSettingsPopUp;
    public AnimationCurve uiSettingsAnimationCurve;
    public GraphicRaycaster uiMainMenuGraphicRaycaster;
    public void OpenSettings() 
    {
        uiSettings.SetActive(true);
        uiSettingsPopUp.DOScale(1, 0.2f).SetEase(uiSettingsAnimationCurve);
        uiMainMenuGraphicRaycaster.enabled = false;
    }

    //public void CloseSettings() 
    //{
    //    uiSettings.SetActive(true);
    //    uiSettingsPopUp.DOScale(0.5f, 0.1f).SetEase(uiSettingsAnimationCurve);

    //}

    public void ClosePopUp() 
    {
        uiSettings.SetActive(false);
    }

    public void CloseSettings() 
    {
        TweenCallback tweenCallback;
        tweenCallback = new TweenCallback(ClosePopUp);
        Tween tween = uiSettingsPopUp.DOScale(0.0f, 0.2f).SetEase(uiSettingsAnimationCurve).OnComplete(tweenCallback);

        uiMainMenuGraphicRaycaster.enabled = true;
    }
}
