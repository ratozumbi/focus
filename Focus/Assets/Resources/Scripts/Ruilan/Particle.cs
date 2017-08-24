using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    [SerializeField]
    private float Velocity;
    [SerializeField]
    private float value;

    private void Update()
    {
        transform.Translate(Vector3.up * Velocity);
    }

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
        if(this.gameObject.tag == "ParticleGood")
            ScoreManager.AddPointer(value);
        if(this.gameObject.tag == "ParticleBad")
            ScoreManager.SubPointer(value);
        Debug.Log("Colision " + gameObject.name);
    }
}
