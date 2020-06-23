using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertEffectSample : MonoBehaviour
{

    [SerializeField] protected RenderTexture realWorldImage, effectedWorldImage;
    [SerializeField] protected Material material;

    void Start()
    {
    }

    void Update()
    {
        Graphics.Blit(
            realWorldImage,  // _MainTex
            effectedWorldImage, 
            material
        );
    }

}
