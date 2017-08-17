using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static float Score { get; private set; }

    static LightBehaviour light;

    private void Awake()
    {
        light = GameObject.FindObjectOfType<LightBehaviour>();
    }

    public static void AddPointer()
    {
        Score = Score + 0.1f;
        if(!light) light = GameObject.FindObjectOfType<LightBehaviour>();
        light.SizeLight();
    }
}
