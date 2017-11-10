using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackTime: MonoBehaviour
{

	[SerializeField] private GameObject timer;
	[SerializeField] private float timerToReduce;


	// Use this for initialization
	void Start ()
	{
		timer = GameObject.Find ("Timer");

		TimerPlayer timerObj = timer.GetComponent<TimerPlayer> ();
		timerObj.secCurrent -= timerToReduce; 

		Destroy (this.gameObject);

	}
}

