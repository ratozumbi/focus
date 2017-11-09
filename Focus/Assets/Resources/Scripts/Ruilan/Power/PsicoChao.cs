using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsicoChao : MonoBehaviour {
	
	[SerializeField] private Sprite original;
	[SerializeField] private Sprite altered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivatePsico()
	{
		GetComponent<SpriteRenderer>().sprite = altered;
	}

	public void DeactivatePsico()
	{
		GetComponent<SpriteRenderer>().sprite = original;
	}

}
