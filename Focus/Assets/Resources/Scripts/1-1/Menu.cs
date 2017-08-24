using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {


    private VirtualJoystick joystick;

    // Use this for initialization
    void Start () {
        joystick = GameObject.Find("Canvas").GetComponentInChildren<VirtualJoystick>(true);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if(joystick.Horizontal() < 0.01 || joystick.Vertical() < 0.01)
        {
            GameObject.Find("menu").SetActive(true);
        }
        else
        {
            GameObject.Find("menu").SetActive(false);
        }
	}
}
