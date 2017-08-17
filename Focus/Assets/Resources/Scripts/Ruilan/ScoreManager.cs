using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int Score { get; private set; }


    public static void AddPointer()
    {
        ++Score;
    }
}
