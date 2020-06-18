using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectSample : MonoBehaviour
{

    [SerializeField] protected RenderTexture realWorldImage, effectedWorldImage;
    [SerializeField] protected Material material;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // source: World Cameraで書かれた内容
        // destination: target texture(画面に表示されるTexture)

        Graphics.Blit(source, destination);
    }

}
