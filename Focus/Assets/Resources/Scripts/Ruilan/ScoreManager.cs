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

    public static void AddPointer(float value)
    {
        Score = Score > 100 ? Score : Score + value;
        if(Score >= 100)
        {
            return;
        }
        if (!light) light = GameObject.FindObjectOfType<LightBehaviour>();
        light.SizeLight();
    }

    public static void SubPointer(float value)
    {
        Score = Score < 0 ? Score : Score - value;
        if (Score <= 0)
        {
            return;
        }
        if (!light) light = GameObject.FindObjectOfType<LightBehaviour>();
        light.SizeLight();
    }
}
