using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSensory : MonoBehaviour {

    [SerializeField] private TypeBubbleSensory typeSensory;
    [SerializeField] private int scoreEarned;

    private bool actived;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !actived)
        {
            SensoryHUD.instance.AddScore(scoreEarned, typeSensory);
            actived = true;
        }
    }
}
