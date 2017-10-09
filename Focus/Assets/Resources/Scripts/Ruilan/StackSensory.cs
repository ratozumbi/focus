using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackSensory : MonoBehaviour {

    [SerializeField] private Image imgActived;

    public bool IsActived { get; private set; }
    


    public void ActiveStack()
    {
        IsActived = true;
        imgActived.enabled = true;
    }
}
