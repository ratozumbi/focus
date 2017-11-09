using UnityEngine;
using System.Collections;

public class PsicoReveal : MonoBehaviour
{

	public GameObject theRevelation; 

	private GameObject instance;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ActivatePsico()
	{
		Destroy (instance);
		instance = Instantiate (theRevelation,GetComponent<Transform>());

	}

	public void DeactivatePsico()
	{
		Destroy (instance);
	}
}

