using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    public float speed = 200.0f;
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }


    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        Rigidbody.AddForce(direction * this.speed);
        
    }

    public void AddForce(Vector2 direction)
    {
        Rigidbody.AddForce(direction);
    }

    public void ResetPosition()
    {
        Rigidbody.position = new Vector2(0,0);
        Rigidbody.velocity = new Vector2(0,0);
    }

    public Vector2 GetPosition()
    {
        return Rigidbody.position;
    }

    public Vector2 GetVelocity()
    {
        return (Rigidbody.velocity);
    }


}
