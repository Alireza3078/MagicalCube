using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField][Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float t = 0;
    public float speed = 2.5f;

    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        transform.position = new Vector3(5, 7, 0);
        transform.localScale = Vector3.one * 1.3f;
        
    }

    void Update()
    {
        Renderer.material.color = Color.Lerp(Renderer.material.color, myColors[colorIndex], lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex=(colorIndex>=myColors.Length) ? 0 : colorIndex;
        }
        transform.Rotate(10.0f * Time.deltaTime * speed, 0.0f , 30.0f * Time.deltaTime * speed);
    }
}
