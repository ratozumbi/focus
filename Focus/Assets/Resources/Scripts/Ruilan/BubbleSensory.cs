using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSensory : MonoBehaviour {

    [SerializeField] private TypeBubbleSensory typeBubble;
    [SerializeField] private int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "??????")
            SensoryHUD.instance.AddScore(score, typeBubble);
    }
}

public enum TypeBubbleSensory { Adrenaline, Feel, Hearing, Sould }