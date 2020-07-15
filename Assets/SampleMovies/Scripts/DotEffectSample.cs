using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEffectSample : MonoBehaviour
{
    [SerializeField] protected RenderTexture realWorldImage, effectedWorldImage;
    [SerializeField] protected Material material_dot;

    void Start()
    {
    }

    void Update()
    {
        Graphics.Blit(
            realWorldImage,  // _MainTex
            effectedWorldImage,
            material_dot
        );
    }

    protected void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, 512, 512), effectedWorldImage);
    }
}
