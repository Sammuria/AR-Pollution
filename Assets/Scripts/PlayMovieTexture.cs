using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayMovieTexture : MonoBehaviour
{
    public RawImage rawimage;
    public Texture m_MainTexture;
    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        WebCamTexture webcamTexture = new WebCamTexture();

        m_Renderer.material.SetTexture("_MainTex", webcamTexture);
        webcamTexture.Play();

        /*
        WebCamTexture webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        */

    }
}