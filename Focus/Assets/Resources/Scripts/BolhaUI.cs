using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BolhaUI : MonoBehaviour, IPointerDownHandler
{

	private float born;
	public float lifeTime = 10f;


	// Use this for initialization
	void Start ()
	{
		born = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.realtimeSinceStartup - born > lifeTime) {
			Destroy (this.gameObject);		
		}
	
	}

	public virtual void OnPointerDown(PointerEventData ped){
        ScoreManager.AddPointer();
        Debug.Log(ScoreManager.Score);
        Destroy (this.gameObject);		
	}

}

