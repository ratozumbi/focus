using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSensory : MonoBehaviour {

    [SerializeField] private Image imgScore;

    public float maxScore;

    public float ScoreCurrent { get; private set; }

    public void AddPointer(float pointerAdd)
    {

        ScoreCurrent += pointerAdd;

        imgScore.fillAmount = ScoreCurrent / maxScore;
    }

    public void ClearScore()
    {
        imgScore.fillAmount = 0f;
        ScoreCurrent = 0;
    }
}
