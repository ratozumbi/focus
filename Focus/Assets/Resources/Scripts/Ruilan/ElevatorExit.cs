using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorExit : MonoBehaviour {

    [SerializeField] private int velocity;
    [SerializeField] private Transform[] pos;
    [SerializeField] private GameObject colissions;
    [SerializeField] private VirtualJoystick joystick;

    private Transform player;

    public static bool cameIn;
    private bool inElevator = false;
    private int nextPosIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !ElevatorEntry.cameIn)
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
            ElevatorEntry.cameIn = false;
        }
    }

    private void Update()
    {
        if (inElevator)
        {
            player.position = Vector3.Lerp(player.position, pos[nextPosIndex].position, Time.deltaTime * velocity);

            Debug.Log((player.position.x.ToString("n0") + " === " + pos[nextPosIndex].position.x.ToString("n0")));
            if (player.position.x.ToString("n0") == pos[nextPosIndex].position.x.ToString("n0") && player.position.y.ToString("n0") == pos[nextPosIndex].position.y.ToString("n0"))
            {
                Debug.Log("Next Pos");
                nextPosIndex++;
            }

            if (player.position.x.ToString("n0") == pos[pos.Length - 1].position.x.ToString("n0") && player.position.y.ToString("n0") == pos[pos.Length - 1].position.y.ToString("n0"))
            {
                inElevator = false;
                colissions.SetActive(true);
                nextPosIndex = 0;
                joystick.enabled = true;
                Debug.Log("Finish Elevator");
            }
        }
    }
}
