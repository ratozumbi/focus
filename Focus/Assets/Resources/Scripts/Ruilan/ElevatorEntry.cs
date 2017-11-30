using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEntry : MonoBehaviour {

    [SerializeField] private Transform[] pos;
    [SerializeField] private GameObject colissions;
    [SerializeField ]private VirtualJoystick joystick;

    private Transform player;

    public static bool cameIn;
    private bool inElevator = false;
    private int nextPosIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !ElevatorExit.cameIn)
        {
            player = collision.transform;
            inElevator = true;
            cameIn = true;
            colissions.SetActive(false);
            joystick.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ElevatorExit.cameIn = false;
        }
    }

    private void Update()
    {
        if(inElevator)
        {
            player.position = Vector3.Lerp(player.position, pos[nextPosIndex].position, Time.deltaTime);

            if (player.position.x.ToString("n0") == pos[nextPosIndex].position.x.ToString("n0") && player.position.y.ToString("n0") == pos[nextPosIndex].position.y.ToString("n0"))
            {
                Debug.Log("Next Pos");
                nextPosIndex++;
            }

            if (player.position.x.ToString("n0") == pos[pos.Length -1].position.x.ToString("n0") && player.position.y.ToString("n0") == pos[pos.Length -1].position.y.ToString("n0"))
            {
                inElevator = false;
                nextPosIndex = 0;
                colissions.SetActive(true);
                joystick.enabled = true;
                Debug.Log("Finish Elevator");
            }
        }
    }
}
