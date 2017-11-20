using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbFocus : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Transform focus;
    [SerializeField] private GameObject bubbleAbsorb;
    [SerializeField] private float absorbScore;


	[SerializeField] private Sprite img0;
	[SerializeField] private Sprite img1;
	[SerializeField] private Sprite img2;

    [SerializeField] private GameObject itemDrop;
    [SerializeField] private Transform posDropItem;

    private Transform transBubble;

    private bool isAbsorb;
	private bool setInactive;
	private float scoreLost = 0;

    private ScoreManager score;

    // Use this for initialization
    void Awake () {
        transBubble = bubbleAbsorb.transform;
        score = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        posDropItem.position = new Vector3(posDropItem.position.x, posDropItem.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(scoreLost);
        if (isAbsorb)
        {
            float step = speed * Time.deltaTime;

            transBubble.position = Vector3.MoveTowards(transBubble.position, this.transform.position, step);

            if (transBubble.position == transform.position)
            {
                transBubble.position = focus.position;
                ScoreManager.SubPointer(absorbScore);

				scoreLost += absorbScore;

                if (scoreLost == 1f)
                {
                    GetComponent<SpriteRenderer>().sprite = img0;
                }
                else if (scoreLost == 2f)
                {
                    GetComponent<SpriteRenderer>().sprite = img1;
                }
                else if (scoreLost >= 3f)
                {
                    GetComponent<SpriteRenderer>().sprite = img2;
                    if (itemDrop != null)
                    {
                        Instantiate(itemDrop, posDropItem.position, posDropItem.rotation, transform);
                        itemDrop = null;
                    }
					setInactive = true;
					transform.parent.gameObject.GetComponent<EvtLuz> ().enabled = false;
					transform.parent.gameObject.GetComponent<EvtSom> ().enabled = false; 
					transform.parent.gameObject.GetComponent<EvtVibra> ().enabled = false; 
					transform.parent.gameObject.GetComponent<EvtLuzRuim> ().enabled = false;
					transform.parent.gameObject.GetComponent<EvtSomRuim> ().enabled = false; 
					transform.parent.gameObject.GetComponent<EvtVibraRuim> ().enabled = false; 
				}

                if (setInactive) {
                    bubbleAbsorb.SetActive(false);
					isAbsorb = false;
					setInactive = false;
                }
            }
        }
        else
        {
            transBubble.position = focus.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Player" && scoreLost < 3)
        {
            bubbleAbsorb.SetActive(true);
            isAbsorb = true;
			setInactive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //bubbleAbsorb.SetActive(false);
            isAbsorb = false;
			setInactive = true;
        }

        if (collision.gameObject.tag == "BubbleAbsorved")
        {
            transBubble.position = focus.position;
        }
    }
}
