using UnityEngine;

[ExecuteInEditMode]
public class LevelCompleteScreenController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Reveal = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_Reveal", Reveal);
    }
}
