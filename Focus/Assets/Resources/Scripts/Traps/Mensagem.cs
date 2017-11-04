using UnityEngine;
using System.Collections;

public class Mensagem : MonoBehaviour
{

	[SerializeField] private int delay = 6;

	void Start ()
	{
		Destroy (this.gameObject, delay);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			ScoreManager.SubPointer (1);
			Destroy (this.gameObject);
		}
	}

}

