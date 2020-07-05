using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldMode
{
    Default,
    Inverted,
    Stitched,
};

public class CaptureImage : MonoBehaviour
{

    [SerializeField] protected RenderTexture image;
    [SerializeField] protected RenderTexture inverted;

    [SerializeField] protected WorldMode mode = WorldMode.Default;
    // images

    void Start()
    {
    }

    void Update()
    {
    }

    protected void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, image);

        // Graphics.Blit(source, inverted, invert);
        // Graphics.Blit(source, stitched, stich);

        switch(mode)
        {
            case WorldMode.Default:
                Graphics.Blit(source, destination); // default 
                break;
            case WorldMode.Inverted:
                Graphics.Blit(inverted, destination);
                break;
            default:
                Graphics.Blit(source, destination); // default 
                break;
        }

        // Graphics.Blit(source, destination);
    }

    protected void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;

        if(name == "Plane_inverted")
        {
            Debug.Log("Hit Plane_inverted");
            mode = WorldMode.Inverted;
        }
    }

}
