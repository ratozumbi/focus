using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbFocus : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Transform focus;
    [SerializeField] private GameObject bubbleAbsorb;
    [SerializeField] private float absorbScore;

    private Transform transBubble;

    private bool isAbsorb;

    private ScoreManager score;

    // Use this for initialization
    void Awake () {
        transBubble = bubbleAbsorb.transform;
        score = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isAbsorb)
        {
            float step = speed * Time.deltaTime;

            transBubble.position = Vector3.MoveTowards(transBubble.position, this.transform.position, step);

            if (transBubble.position == transform.position)
            {
                transBubble.position = focus.position;
                ScoreManager.SubPointer(absorbScore);
            }
        }
        else
        {
            transBubble.position = focus.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bubbleAbsorb.SetActive(true);
            isAbsorb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bubbleAbsorb.SetActive(false);
            isAbsorb = false;
        }

        if (collision.gameObject.tag == "BubbleAbsorved")
        {
            transBubble.position = focus.position;
        }
    }
}
