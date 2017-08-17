using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FundoWeb2D : MonoBehaviour
{

    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    [SerializeField] private MeshRenderer background;

    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        background.material.mainTexture = backCam;

        backCam.Play();

        camAvailable = true;
    }

    private void Update()
    {
        if (!camAvailable)
        {
            return;
        }

    }
}

