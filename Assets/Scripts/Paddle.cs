using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    public float speed = 45.0f;
    private Renderer _renderer;
    protected bool OnLeft;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        OnLeft = Rigidbody.position.x < 0.0f;
    }
    
    public void ResetPosition()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.position = new Vector2(Rigidbody.position.x, 0.0f);
    }

    protected void UpdateColor()
    {
        float greenValue = Rigidbody.position.y / 15 + 0.5f;
        _renderer.material.color = new Color(1.0f, greenValue, 0.0f, 1.0f);
    }
}
