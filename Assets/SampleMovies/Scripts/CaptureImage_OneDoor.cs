using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public enum WorldMode_Single
{
    Default,
    Inverted
};

public class CaptureImage_OneDoor : MonoBehaviour
{
    [SerializeField] protected ARCameraBackground arCamBg;

    [SerializeField] protected RenderTexture image;
    [SerializeField] protected RenderTexture inverted;

    [SerializeField] protected WorldMode_Single mode = WorldMode_Single.Default;

    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Graphics.Blit(null, image, arCamBg.material);
    }

    protected void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        switch (mode)
        {
            case WorldMode_Single.Default:
                Graphics.Blit(source, destination); // default 
                break;
            case WorldMode_Single.Inverted:
                Graphics.Blit(inverted, destination);
                break;
            default:
                Graphics.Blit(source, destination); // default 
                break;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;

        switch (name)
        {
            case "Plane_inverted":
                Debug.Log("Hit Plane_inverted");
                num++;
                if(num % 2 == 1)
                {
                    
                }
                else
                {
                    mode = WorldMode_Single.Default;
                }
                break;
            default:
                mode = WorldMode_Single.Default;
                break;
        }
    }
}
