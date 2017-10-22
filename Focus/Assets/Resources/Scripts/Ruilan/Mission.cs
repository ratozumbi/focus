using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DescriptionMission
{
    public string titleMission;
    public bool isCompleted;
    public bool inProgress;
    [TextArea]
    public string[] textBubbleDescription;
    public Item itemRequested;
    public TypeBubbleSensory typeSensory;
    public int scoreEarned;
    public GameObject itemDrop;
    public Transform posDropItem;
}

public class Mission : MonoBehaviour {

    [SerializeField] private SpriteRenderer spriteBubble;
	[SerializeField] private Sprite sprtDone;
    [SerializeField] private TextMesh textBubble;

    [SerializeField] private DescriptionMission[] missions;

    private Inventory inventoryPlayer;

    private void Awake()
    {
        inventoryPlayer = FindObjectOfType<Inventory>();
    }

    public void ActiveMission()
    {
        for (int i = 0; i < missions.Length; i++)
        {
            if (!missions[i].isCompleted)
            {
                if (!missions[i].inProgress)
                {
                    missions[i].inProgress = true;
                    StartCoroutine(BubbleSpeaksAsyc(missions[i]));
                    break;
                }
                else
                {
                    CheckFinishMission(ref missions[i]);
                    break;
                }

            }
        }
    }

    private void CheckFinishMission(ref DescriptionMission mission)
    {
        for (int i = 0; i < inventoryPlayer.itemSlot.Length; i++)
        {
            if (GameObject.Equals(inventoryPlayer.itemSlot[i].itemInSlot, mission.itemRequested))
            {
                mission.inProgress = false;
                mission.isCompleted = true;

				spriteBubble.sprite = sprtDone;

                inventoryPlayer.itemSlot[i].Removed();
                SensoryHUD.instance.AddScore(mission.scoreEarned, mission.typeSensory);

                Instantiate(mission.itemDrop, mission.posDropItem.position, mission.posDropItem.rotation, transform);

                FinishGame.instance.ActiveFinishGameEffect();
                break;
            }
        }

        Debug.Log("FinishMission");
    }

    private IEnumerator BubbleSpeaksAsyc(DescriptionMission mission)
    {
        Debug.Log("Bubble Speak actived");
        spriteBubble.gameObject.SetActive(true);

        for (int i = 0; i < mission.textBubbleDescription.Length; i++)
        {
            textBubble.text = mission.textBubbleDescription[i];
            yield return new WaitForSeconds(5);
        }

       // spriteBubble.gameObject.SetActive(false);
    }
}
