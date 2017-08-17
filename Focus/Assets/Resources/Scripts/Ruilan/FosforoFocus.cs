using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FosforoFocus : MonoBehaviour {

    [SerializeField] Slider posBallYellow;
    [SerializeField] float posFocusTrigger = 0.266f;

    [SerializeField] private Image imgFocus;
    [SerializeField] private Image imgSlideFocus;

    [SerializeField] private Sprite sprFocus;
    [SerializeField] private Sprite redPillar;

    [SerializeField] private GameObject buttonPlay;

    private void Update()
    {
        if (posBallYellow.value > (posFocusTrigger - 0.01) && posBallYellow.value < posFocusTrigger + 0.01)
        {
            if (imgFocus.sprite == redPillar)
            {
                imgSlideFocus.sprite = sprFocus;
                imgSlideFocus.transform.localScale = new Vector3(4, 8);
                imgFocus.enabled = false;
                buttonPlay.SetActive(true);
                this.enabled = false;
            }
        }
    }
}
