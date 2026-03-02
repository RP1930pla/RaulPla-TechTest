using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEditor;
using Unity.VisualScripting;

[RequireComponent (typeof(RectTransform))]
public class TweeningAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum TweeningModes
    {
         UniformScale = 0,
         Rotate = 1,
         None = 2
    }
    public RectTransform rectTransform;

    public TweeningModes mode = TweeningModes.UniformScale;

    #region UniformScaleProperties
        public AnimationCurve uniformScaleCurve = AnimationCurve.Linear(0,0,1,1);
        public float uniformInitialScale = 1;
        public float uniformEndScale = 1;
        public float uniformScaleDuration = 0.5f;
    #endregion

    #region RotationProperties
    public float rotation = 20f;
    public float timePerRotation = 0.1f;
    public AnimationCurve rotationCurve = AnimationCurve.Linear(0, 0, 1, 1);
    #endregion

    public void UniformScale(float EndScale, float duration)
    {
        rectTransform.DOScale(EndScale, duration).SetEase(uniformScaleCurve);
    }

    public void RotateLocked() 
    {
       DG.Tweening.Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DORotate(new Vector3(0,0,rotation), timePerRotation).SetEase(rotationCurve));
        sequence.Append(rectTransform.DORotate(new Vector3(0,0,-rotation), timePerRotation).SetEase(rotationCurve));
        sequence.Append(rectTransform.DORotate(new Vector3(0,0,0), timePerRotation).SetEase(rotationCurve));
        sequence.Play();
    }

    void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        switch (mode)
        {
            case TweeningModes.UniformScale:
                UniformScale(uniformEndScale, uniformScaleDuration);
                break;
            case TweeningModes.Rotate:
                //RotateLocked();
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (mode)
        {
            case TweeningModes.UniformScale:
                UniformScale(uniformInitialScale, uniformScaleDuration);
                break;
            case TweeningModes.Rotate:
                break;
            default:
                break;
        }
    }
}

[CustomEditor(typeof(TweeningAnimation))]
public class TweeningAnimationEditor : Editor 
{
    override public void OnInspectorGUI()
    {
        var script = target as TweeningAnimation;
        script.mode = (TweeningAnimation.TweeningModes)EditorGUILayout.EnumPopup("Mode", script.mode);
        script.rectTransform = (RectTransform)EditorGUILayout.ObjectField("Rect Transform",script.rectTransform, typeof(RectTransform), true);
        switch (script.mode)
        {
            case TweeningAnimation.TweeningModes.UniformScale:
                script.uniformInitialScale = EditorGUILayout.FloatField("Uniform Initial Scale", script.uniformInitialScale);
                script.uniformEndScale = EditorGUILayout.FloatField("Uniform End Scale", script.uniformEndScale);
                script.uniformScaleDuration = EditorGUILayout.FloatField("Uniform End Duration", script.uniformScaleDuration);
                script.uniformScaleCurve = EditorGUILayout.CurveField("Uniform Scale Curve", script.uniformScaleCurve);
                break;
            case TweeningAnimation.TweeningModes.Rotate:
                script.rotation = EditorGUILayout.FloatField("Rotation", script.rotation);
                script.timePerRotation = EditorGUILayout.FloatField("Rotation duration", script.timePerRotation);
                script.rotationCurve = EditorGUILayout.CurveField("Rotation Curve", script.rotationCurve);
                break;
            case TweeningAnimation.TweeningModes.None:
                script.uniformInitialScale = EditorGUILayout.FloatField("Uniform Initial Scale", script.uniformInitialScale);
                script.uniformEndScale = EditorGUILayout.FloatField("Uniform End Scale", script.uniformEndScale);
                script.uniformScaleDuration = EditorGUILayout.FloatField("Uniform End Duration", script.uniformScaleDuration);
                script.uniformScaleCurve = EditorGUILayout.CurveField("Uniform Scale Curve", script.uniformScaleCurve);

                script.rotation = EditorGUILayout.FloatField("Rotation", script.rotation);
                script.timePerRotation = EditorGUILayout.FloatField("Rotation duration", script.timePerRotation);
                script.rotationCurve = EditorGUILayout.CurveField("Rotation Curve", script.rotationCurve);

                break;
            default:
                break;
        }
    }
}
