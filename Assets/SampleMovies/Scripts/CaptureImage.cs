﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldMode
{
    Default,
    Inverted,
    Line,
    Stitched,
};

public class CaptureImage : MonoBehaviour
{

    [SerializeField] protected RenderTexture image;
    [SerializeField] protected RenderTexture inverted;
    [SerializeField] protected RenderTexture line;

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
            case WorldMode.Line:
                Graphics.Blit(line, destination);
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
            default:
                mode = WorldMode.Default;
                break;
        }
    }

}
