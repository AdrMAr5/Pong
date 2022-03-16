using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManagement : MonoBehaviour
{
    public ParticleSystem collisionParticles;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = collisionParticles.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            _rigidBody.position = collision.GetContact(0).point;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            collisionParticles.Emit(100);
        }
    }
}
