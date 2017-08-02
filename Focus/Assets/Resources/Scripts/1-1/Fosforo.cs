using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fosforo : MonoBehaviour {
    public float F_Pos = 0.1f;
    public float C_Pos = 0.36f;
    public float U1_Pos = 0.55f;
    public float U2_Pos = 0.71f;
    public float S_Pos = 0.83f;

    public float []slidePos = 

    private GameObject F;
    private GameObject O;
    private GameObject C;
    private GameObject U1;
    private GameObject U2;
    private GameObject S;

    private GameObject barraEQ;
    private Slider slider;
    // Use this for initialization
    void Start () {

        F = GameObject.Find("F");
        O = GameObject.Find("O");
        C = GameObject.Find("C");
        U1 = GameObject.Find("U1");
        U2 = GameObject.Find("U2");
        S = GameObject.Find("S");

        barraEQ = GameObject.Find("equilibrio");
        slider = barraEQ.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update() {

        if (slider.value > F_Pos - 0.01 && slider.value < F_Pos + 0.01)
        {

        }

	
	}
}
