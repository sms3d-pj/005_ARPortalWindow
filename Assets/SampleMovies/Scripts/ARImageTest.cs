using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageTest : MonoBehaviour
{
    [SerializeField] protected ARCameraBackground arCamBg;
    [SerializeField] protected RenderTexture image;

    void Start()
    {
    }

    void Update()
    {
        Graphics.Blit(null, image, arCamBg.material);
    }

    protected void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, 512, 512), image);
    }

}
