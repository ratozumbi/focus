using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField] private Teleport teleportLink;
    [SerializeField] private GameObject colliderTop; //Adicionar valor apenas no teleporte de baixo

    private Transform posTeleportLink;
    new private Collider2D collider;

    public bool IsExitTeleport { get; set; }

    private void Awake()
    {
        posTeleportLink = teleportLink.transform;
        collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        posTeleportLink.position = new Vector3(posTeleportLink.position.x, posTeleportLink.position.y, -0.83f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !IsExitTeleport)
        {
            for (int i = 0; i < Inventory.instance.itemSlot.Length; i++)
            {
                if (!Inventory.instance.itemSlot[i].IsEmpty && Inventory.instance.itemSlot[i].itemInSlot.power == Power.Jump)
                {
                    teleportLink.IsExitTeleport = true;
                    collision.gameObject.transform.position = posTeleportLink.position;

                    if (colliderTop != null)
                        colliderTop.SetActive(true);
                    if (teleportLink.gameObject.name == "Teleport-Two")
                        teleportLink.gameObject.SetActive(true);
                    break;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsExitTeleport)
        {
            IsExitTeleport = false;
            if (colliderTop != null)
                colliderTop.SetActive(false);

            if (teleportLink.gameObject.name == "Teleport-Two")
                teleportLink.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        posTeleportLink = teleportLink.transform;
        Gizmos.DrawLine(this.transform.position, posTeleportLink.position);
    }
}
