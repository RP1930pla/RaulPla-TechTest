using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    public GameObject uiSettings;
    public RectTransform uiSettingsPopUp;
    public AnimationCurve uiSettingsAnimationCurve;
    public GraphicRaycaster uiMainMenuGraphicRaycaster;

    public Texture2D screenShot;
    public RawImage sprite;



    IEnumerator RecordFrame() 
    {
        yield return new WaitForEndOfFrame();
        var screenTex = ScreenCapture.CaptureScreenshotAsTexture();
        screenShot = new Texture2D(screenTex.width, screenTex.height, TextureFormat.RGB24, false);
        screenShot.SetPixels(screenTex.GetPixels());
        screenShot.Apply();
        sprite.texture = screenShot;

        Destroy(screenTex);
        OpenUISettingsPanel();
    }

    public void OpenUISettingsPanel() 
    {
        uiSettings.SetActive(true);
        uiSettingsPopUp.DOScale(1, 0.2f).SetEase(uiSettingsAnimationCurve);
        uiMainMenuGraphicRaycaster.enabled = false;
    }

    public void OpenSettings() 
    {
        StartCoroutine(RecordFrame());
    }

    public void ClosePopUp() 
    {
        uiSettings.SetActive(false);
        Destroy(screenShot);
    }

    public void CloseSettings() 
    {
        TweenCallback tweenCallback;
        tweenCallback = new TweenCallback(ClosePopUp);
        Tween tween = uiSettingsPopUp.DOScale(0.0f, 0.2f).SetEase(uiSettingsAnimationCurve).OnComplete(tweenCallback);

        uiMainMenuGraphicRaycaster.enabled = true;
    }
}
