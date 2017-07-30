using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class IntroGC : MonoBehaviour {

    private GameObject logo;

    private int currEvtFase = 0;

    private float timer = 0;
    private Image img;
    
    // Use this for initialization
    void Start () {
        logo = GameObject.Find("logo");
        img = logo.GetComponent<Image>();

        timer = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        switch (currEvtFase)
        {

            case 0:
                if (Time.time - timer > 3f)
                {
                    img.color = new Color(255, 255, 255, img.color.a + 0.01f);
                    if (img.color.a > 0.999)
                    {
                        timer = Time.time;
                        currEvtFase = 1;
                    }
                }
                break;
            case 1:
                Debug.Log("stage 1");
                if (Time.time - timer > 3f)
                {
                    img.color = new Color(255, 255, 255, img.color.a - 0.01f);
                    if (img.color.a < 0.001)
                    {
                        currEvtFase = 2;
                        logo.SetActive(false);
                    }
                        
                }
                break;
        }
	
	}

    private void loop1()
    {

        Color col = img.color;
        col.a = 255;

        if (Time.time > 2f && Time.time < 3f)
        {
            Color.Lerp(img.color, col, Time.deltaTime);
        }
        else if (Time.time > 3f)
        {
            col.a -= 1;
            if (col.a == 0)
            {
                currEvtFase = 1;
            }
        }

        img.color = col;

    }
}
