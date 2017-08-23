using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPlayer : MonoBehaviour
{

    [SerializeField]
    private int secMax;
    private float secCurrent;

    public bool ActiveTimer { get; set; }

    private Image imageTime;

    private void Awake()
    {
        imageTime = GetComponent<Image>();
    }

    // Use this for initialization 
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame 
    void Update()
    {
        secCurrent += Time.deltaTime;
        CalculatePercentage(secMax, secCurrent);

    }

    public void ResetTimer()
    {
        imageTime.fillAmount = 0;
        secCurrent = 0.0f;
    }

    private void CalculatePercentage(int secMax, float secCurr)
    {
        imageTime.fillAmount = secCurr / secMax;
    }
}