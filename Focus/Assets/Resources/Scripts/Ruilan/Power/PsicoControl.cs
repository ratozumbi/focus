﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsicoControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NotifyAll(bool ativa)
	{
		if (ativa) {
			BroadcastMessage ("ActivatePsico");
		} else {
			BroadcastMessage ("DeactivatePsico");
		}

	}

}

