using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Focus"))
        {
            ReactionColisionParticle();
            gameObject.SetActive(false);
        }
    }

    public virtual void ReactionColisionParticle()
    {
        Debug.Log("Colision " + gameObject.name);
    }
}
