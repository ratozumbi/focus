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


		if(scoreLost > 1)
		{
			GetComponent<SpriteRenderer>().sprite = img0;
        }

		if(scoreLost > 2)
		{
			GetComponent<SpriteRenderer>().sprite = img1;
        }

		if(scoreLost > 3)
		{
			GetComponent<SpriteRenderer>().sprite = img2;

			setInactive = true;
        }
			

        if (isAbsorb)
        {
            float step = speed * Time.deltaTime;

            transBubble.position = Vector3.MoveTowards(transBubble.position, this.transform.position, step);

            if (transBubble.position == transform.position)
            {
                transBubble.position = focus.position;
                ScoreManager.SubPointer(absorbScore);

				scoreLost += absorbScore;

				if (setInactive) {
                    bubbleAbsorb.SetActive(false);
					isAbsorb = false;
					setInactive = false;

                    if (itemDrop != null)
                        Instantiate(itemDrop, posDropItem.position, posDropItem.rotation, transform);
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
            //isAbsorb = false;
			setInactive = true;
        }

        if (collision.gameObject.tag == "BubbleAbsorved")
        {
            transBubble.position = focus.position;
        }
    }
}
