using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour {

    [SerializeField] private Slider focusPosition;

    private RectTransform imglight;

    private float rotZMin = -50;
    private float zoomMax = -150;
    private float zoommin = 0;

	// Use this for initialization
	void Start () {
        imglight = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        CalculateRot();
        Calculateheight();
    }

    private void CalculateRot()
    {
        float posFocus = focusPosition.value;
        imglight.rotation = Quaternion.Euler(0, 0, -(rotZMin + (100 * posFocus)));
    }

    private void Calculateheight()
    {
        float posFocus = focusPosition.value;
        float valDisplaced;

        if (posFocus > 0.5)
            valDisplaced = posFocus;
        else if (posFocus < 0.5)
            valDisplaced = posFocus + 1;
        else
            valDisplaced = 0;

        float rotImg = (imglight.rotation.z < 0) ? (imglight.rotation.z * -1) : imglight.rotation.z;
        float valTop = ((rotImg * 3.5f) * valDisplaced) * 200;

        imglight.offsetMax = new Vector2(imglight.offsetMax.x, valTop);

        Debug.Log(valDisplaced + " - " + ((imglight.rotation.z * 3.5f) * valDisplaced) * 200);
    }
}
