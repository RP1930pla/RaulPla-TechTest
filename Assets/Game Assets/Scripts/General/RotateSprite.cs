using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RotateSprite : MonoBehaviour
{

    public RectTransform rectTransform;
    public float speed;
    void Update()
    {
        rectTransform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
