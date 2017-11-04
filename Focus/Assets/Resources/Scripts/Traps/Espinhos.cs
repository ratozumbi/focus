using UnityEngine;
using System.Collections;

public class Espinhos : MonoBehaviour
{

	[SerializeField] private GameObject objTrap;
	[SerializeField] private GameObject player;

	[SerializeField] private int qtdToGen = 8;

	[SerializeField] private int delay = 0;
	[SerializeField] private int radius = 4;

	[SerializeField] private int duration = 6;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		StartCoroutine(doGen());
	
	}

	IEnumerator doGen(){
		
		for (int i = 0; i < qtdToGen; i++) {

			Vector3 objPos;
			objPos = Random.insideUnitCircle * radius;

			//while (objPos.x < 1 || objPos.y < 1) {
			//	objPos = Random.insideUnitCircle * 4;
			//}

			objPos += player.transform.position;

			GameObject espinho = Instantiate(objTrap, objPos, Quaternion.identity);

			Destroy (espinho, duration);
		
			yield return new WaitForSeconds(delay);

		}


		Destroy (this.gameObject);


	}


	// Update is called once per frame
	void Update ()
	{
	
	}
}

