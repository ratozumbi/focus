using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class JoyBreath : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image bgImg;
    private Image joyImg;
    private Vector3 inputVector;


	[SerializeField] private Transform pointerSpawn;


	[SerializeField] private GameObject camBackground;

	[SerializeField] private GameObject headRespira;
	[SerializeField] private Image tutorialRespira;
	private Image headRespiraImg;

    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private GameObject timer;

    private Transform[] posSpawns;

    private bool lastPosBreath;

    private void Start()
    {

		headRespiraImg = headRespira.GetComponent<Image> ();
		headRespiraImg.enabled = true;

		tutorialRespira.enabled = true;

        bgImg = GetComponent<Image>();
        joyImg = transform.GetChild(0).GetComponent<Image>();

        posSpawns = pointerSpawn.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(lastPosBreath && inputVector.z < 0.8f)
        {
            lastPosBreath = false;
            int posRandom = Random.Range(0, posSpawns.Length);
            Instantiate(spawn, posSpawns[posRandom]);
        }
        else if(!lastPosBreath && inputVector.z > 0.8f)
        {
            lastPosBreath = true;
            int posRandom = Random.Range(0, posSpawns.Length);
            Instantiate(spawn, posSpawns[posRandom]);
        }

		//scala a cabeça
		headRespira.transform.localScale = new Vector3(
			1 + headRespira.transform.localScale.x * inputVector.z / 8,
			1 + headRespira.transform.localScale.y * inputVector.z / 8,
			1 + headRespira.transform.localScale.z * inputVector.z / 8);

        if (ScoreManager.Score > 2.5f)
        {
            GameObject joyBreath = GameObject.FindObjectOfType<JoyBreath>().gameObject;
            joyBreath.SetActive(false);

            GameObject joyStick = GameObject.Find("Canvas").GetComponentInChildren<VirtualJoystick>(true).gameObject;
            joyStick.SetActive(true);

			headRespiraImg.enabled = false;
			tutorialRespira.enabled = false;

			camBackground.SetActive (false);

            timer.SetActive(true);
        }


    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        Vibration.Vibrate(50);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

        inputVector = Vector3.zero;
        joyImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);

            inputVector = inputVector.magnitude > 1 ? inputVector.normalized : inputVector;

            joyImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * bgImg.rectTransform.sizeDelta.x / 3, inputVector.z * bgImg.rectTransform.sizeDelta.y / 3);
        }
    }
}
