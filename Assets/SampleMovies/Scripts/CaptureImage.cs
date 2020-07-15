using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public enum WorldMode
{
    Default,
    Inverted,
    Line,
    VHS,
    Dot,
    Film,
    RGB
};

public class CaptureImage : MonoBehaviour
{
    [SerializeField] protected ARCameraBackground arCamBg;

    [SerializeField] protected RenderTexture image;
    [SerializeField] protected RenderTexture inverted;
    [SerializeField] protected RenderTexture line;
    [SerializeField] protected RenderTexture VHS;
    [SerializeField] protected RenderTexture dot;
    [SerializeField] protected RenderTexture film;
    [SerializeField] protected RenderTexture rgb;

    [SerializeField] protected WorldMode mode = WorldMode.Default;
    // images

    void Start()
    {
    }

    void Update()
    {
        Graphics.Blit(null, image, arCamBg.material);
    }

    protected void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(null, image, arCamBg.material);

        switch(mode)
        {
            case WorldMode.Default:
                Graphics.Blit(source, destination); // default 
                break;
            case WorldMode.Inverted:
                Graphics.Blit(inverted, destination);
                break;
            case WorldMode.Line:
                Graphics.Blit(line, destination);
                break;
            case WorldMode.VHS:
                Graphics.Blit(VHS, destination);
                break;
            case WorldMode.Dot:
                Graphics.Blit(dot, destination);
                break;
            case WorldMode.Film:
                Graphics.Blit(film, destination);
                break;
            case WorldMode.RGB:
                Graphics.Blit(rgb, destination);
                break;
            default:
                Graphics.Blit(source, destination); // default 
                break;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;

        switch(name)
        {
            case "Plane_inverted":
                Debug.Log("Hit Plane_inverted");
                mode = WorldMode.Inverted;
                break;
            case "Plane_line":
                Debug.Log("Hit Plane_line");
                mode = WorldMode.Line;
                break;
            case "Plane_VHS":
                Debug.Log("Hit Plane_VHS");
                mode = WorldMode.VHS;
                break;
            case "Plane_dot":
                Debug.Log("Hit Plane_dot");
                mode = WorldMode.Dot;
                break;
            case "Plane_film":
                Debug.Log("Hit Plane_dot");
                mode = WorldMode.Film;
                break;
            case "Plane_rgb":
                Debug.Log("Hit Plane_rgb");
                mode = WorldMode.RGB;
                break;
            default:
                mode = WorldMode.Default;
                break;
        }
    }
}
