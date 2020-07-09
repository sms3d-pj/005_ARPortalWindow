using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffectSample : MonoBehaviour
{
    [SerializeField] protected RenderTexture realWorldImage, effectedWorldImage;
    [SerializeField] protected Material material_line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.Blit(
            realWorldImage,  // _MainTex
            effectedWorldImage,
            material_line
        );
    }
}
