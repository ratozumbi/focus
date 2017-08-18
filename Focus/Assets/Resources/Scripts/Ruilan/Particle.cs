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
        if(this.gameObject.layer == 12)
            ScoreManager.AddPointer();
        if(this.gameObject.layer == 13)
            ScoreManager.SubPointer();
        Debug.Log("Colision " + gameObject.name);
    }
}
