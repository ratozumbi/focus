﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class IntroGC : MonoBehaviour {

    private GameObject logo;

    private int currEvtFase = 0;

    private float timer = 0;
    private Image logoImg;
    
    // Use this for initialization
    void Start () {
        logo = GameObject.Find("logo");
        logoImg = logo.GetComponent<Image>();

        timer = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        switch (currEvtFase)
        {

            case 0:
                if (Time.time - timer > 3f)
                {
                    //surge logo empresa
                    logoImg.color = new Color(255, 255, 255, logoImg.color.a + 0.01f);
                    if (logoImg.color.a > 0.999)
                    {
                        timer = Time.time;
                        currEvtFase = 1;
                    }
                }
                break;
            case 1:
                //some logo empresa
                if (Time.time - timer > 3f)
                {
                    logoImg.color = new Color(255, 255, 255, logoImg.color.a - 0.01f);
                    if (logoImg.color.a < 0.001)
                    {
                        currEvtFase = 2;
                        timer = Time.time;
                        logo.SetActive(false);
                    }

                }
                break;

            case 2:
                //surge tilt e barra
                if (Time.time - timer > 3f)
                {
                    Image[] vecBarra = new Image[8];
                    vecBarra[0] = GameObject.Find("HandleEQ").GetComponent<Image>();
                    vecBarra[1] = GameObject.Find("eqBackground").GetComponent<Image>();
                    vecBarra[2] = GameObject.Find("trigF").GetComponent<Image>();
                    vecBarra[3] = GameObject.Find("trigC").GetComponent<Image>();
                    vecBarra[4] = GameObject.Find("trigU1").GetComponent<Image>();
                    vecBarra[5] = GameObject.Find("trigU2").GetComponent<Image>();
                    vecBarra[6] = GameObject.Find("trigS").GetComponent<Image>();
                    vecBarra[7] = GameObject.Find("tilt").GetComponent<Image>(); 

                    foreach (Image img in vecBarra)
                    {
                        img.color = new Color(255, 255, 255, img.color.a + 0.01f);
                        if (img.color.a > 0.999)
                        {
                            currEvtFase = 3;
                            timer = Time.time;
                        }

                    }

                }
                break;

            case 3:
                //some tilt
                if (Time.time - timer > 3f)
                {
                    logoImg.color = new Color(255, 255, 255, logoImg.color.a - 0.01f);
                    if (logoImg.color.a < 0.001)
                    {
                        currEvtFase = 2;
                        timer = Time.time;
                        logo.SetActive(false);
                    }

                }
                break;

        }
	
	}

}