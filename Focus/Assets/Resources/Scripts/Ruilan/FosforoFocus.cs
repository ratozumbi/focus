using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FosforoFocus : MonoBehaviour {

    [SerializeField] Slider posBallYellow;
    [SerializeField] float posFocusTrigger = 0.266f;

    [SerializeField] private Image imgFocus;

    [SerializeField] private Sprite sprFocus;
    [SerializeField] private Sprite redPillar;

    private void Update()
    {
        if (posBallYellow.value > (posFocusTrigger - 0.01) && posBallYellow.value < posFocusTrigger + 0.01)
        {
            if (imgFocus.sprite == redPillar)
            {
                imgFocus.sprite = sprFocus;
            }
        }
    }
}
