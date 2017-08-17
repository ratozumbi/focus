using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BolhaUI : MonoBehaviour, IPointerDownHandler
{

	private float born;
	public float lifeTime = 10f;

    private MeshRenderer background;
    private Color colorBG;

	// Use this for initialization
	void Start ()
	{
		born = Time.realtimeSinceStartup;

        background = GameObject.Find("Background").GetComponent<MeshRenderer>();
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

        Color color = background.materials[0].color;
        color.a -= 0.1f;
        background.materials[0].color = color;

        Debug.Log(ScoreManager.Score);
        Destroy (this.gameObject);		
	}

}

