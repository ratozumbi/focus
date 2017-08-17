using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFocus : MonoBehaviour {

    [SerializeField] private Image[] letters;

    [SerializeField] private Image imgFocus;

    [SerializeField] private Sprite sprFocus;
    [SerializeField] private Sprite redPillar;

    [SerializeField] private GameObject objectO;

    private Fosforo[] fosforos;
    [SerializeField] private GameObject equilibrio;
    [SerializeField] private FosforoFocus focus;

    private void Start()
    {
        fosforos = equilibrio.GetComponentsInChildren<Fosforo>();
    }

    public void ActiveFocus()
    {
        if (imgFocus.sprite != redPillar && imgFocus.sprite != sprFocus)
        {
            int countActived = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                countActived = (letters[i].isActiveAndEnabled) ? ++countActived : countActived;
            }

            if (countActived == letters.Length)
            {
                if (!objectO.activeSelf)
                {
                    objectO.SetActive(true);
                    imgFocus.sprite = redPillar;
                    DesableFosforo();
                }
                else
                    focus.enabled = true;
            }

        }
    }


    private void DesableFosforo()
    {
        for (int i = 0; i < fosforos.Length; i++)
        {
            fosforos[i].enabled = false;
        }
    }
}
