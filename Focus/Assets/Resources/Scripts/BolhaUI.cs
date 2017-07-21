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
			
			BarraFocus bf = GameObject.Find ("qtdFoco").GetComponent<BarraFocus> ();
			bf.addValue (0.33f);
			Destroy (this.gameObject);		
		}
	
	}

	public virtual void OnPointerDown(PointerEventData ped){
		BarraFocus bf = GameObject.Find ("qtdFoco").GetComponent<BarraFocus> ();
		bf.addValue (0.33f);
		Destroy (this.gameObject);		
	}

}

