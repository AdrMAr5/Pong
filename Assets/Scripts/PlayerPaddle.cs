using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 Direction;
    public KeyCode keyUp;
    public KeyCode keyDown;
    private void Update()
    {
        UpdateColor();
        if (Input.GetKey(keyUp))
        {
            Direction = Vector2.up;
        }

        else if (Input.GetKey(keyDown))
        {
            Direction = Vector2.down;
        }
        else
        {
            Direction = Vector2.zero;
        }
        
    }

    private void FixedUpdate()
    {
        if (Direction.sqrMagnitude != 0)
        {
            Rigidbody.AddForce(Direction * this.speed);
        }
    }
}
