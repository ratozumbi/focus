using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Fosforo : MonoBehaviour
{
    public static float F_Pos = 0.1f;
    public static float C_Pos = 0.36f;
    public static float U1_Pos = 0.55f;
    public static float U2_Pos = 0.71f;
    public static float S_Pos = 0.83f;

    public int ativacao = 3;

    public enum Letras : int { F, C, U1, U2, S };
    public Letras letra;

    private float[] slidePos = new float[] { F_Pos, C_Pos, U1_Pos, U2_Pos, S_Pos };
    private int slideCount = 0;
    private bool slideActive = false;

    private GameObject myLetra;

    [SerializeField] private ParticleSystem ps;

    private GameObject barraEQ;
    private Slider slider;

    TriggerFocus focus;
    // Use this for initialization
    void Start()
    {
        focus = GameObject.FindObjectOfType<TriggerFocus>();

        myLetra = transform.Find("letra").gameObject;



        barraEQ = GameObject.Find("equilibrio");
        slider = barraEQ.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {

        if (slider.value > slidePos[(int)letra] - 0.01 && slider.value < slidePos[(int)letra] + 0.01)
        {
            if (slideActive == false)
            {
                slideActive = true;

                //ParticleSystem.EmitParams emitOverride = new ParticleSystem.EmitParams();
                //emitOverride.startLifetime = 1f;
                //ps.Emit(emitOverride, 10);
                ps.Emit(10);

                slideCount++;

                if (slideCount > ativacao)
                {
                    Image myImg = this.GetComponent<Image>();
                    Image imgLetra = myLetra.GetComponent<Image>();

                    //mySpark.SetActive(false);
                    imgLetra.enabled = true;
                    myImg.enabled = false;

                    focus.ActiveFocus();
                }

            }
        }
        else
        {
            slideActive = false;
            //mySpark.SetActive(false);
        }
    }
}
