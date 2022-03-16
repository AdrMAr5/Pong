using System.Threading;
using UnityEngine;
using UnityEngine.TestTools;


public class ComputerPaddle : Paddle
{
    public Ball ball;
    private Vector2 _direction;
    protected int Level;

    private void Update()
    {   
        UpdateColor();
        Vector2 ballPos = ball.GetPosition();
        float ballOffset = ballPos.y - Rigidbody.position.y;
        Vector2 ballDirection = ball.GetVelocity();
        
        switch (Level)
        {
            case 1:
                Level1Movement(ballOffset);
                break;
            case 2:
                Level2Movement(ballOffset, ballDirection.x);
                break;
            case 3:
                Level3Movement(ballOffset, ballDirection);
                break;
            case 4:
                Level4Movement(ballOffset, ballDirection, ballPos);
                break;
        }
        
    }

    private void Level1Movement(float offset)
    {
        if (offset > 1)
        {
            _direction = Vector2.up;
        }
        else if (offset < 1)
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    private void Level2Movement(float offset, float xDirection)
    {
        if ((xDirection < 0 && OnLeft) || (xDirection > 0 && !OnLeft))
            if (offset > 0)
            {
                _direction = Vector2.up;
            }
            else if (offset < 0)
            {
                _direction = Vector2.down;
            }
            else
            {
                _direction = Vector2.zero;
            }
        else
        {
            GoToCenter();
        }
    }

    
    private void Level3Movement(float offset, Vector2 direction)
    {
        float xDirection = direction.x;
        float yDirection = direction.y;
        if ((xDirection < 0 && OnLeft) || (xDirection > 0 && !OnLeft))
            if (offset > 0 && yDirection > 0)
            {
                _direction = Vector2.up;
            }
            else if (offset < 0 && yDirection < 0)
            {
                _direction = Vector2.down;
            }
            else
            {
                _direction = Vector2.zero;
            }
        else
        {
            GoToCenter();
        }
    }
    
    private void Level4Movement(float offset, Vector2 direction, Vector2 ballPos)
    {
        float xDirection = direction.x;
        float yDirection = direction.y;
        if ((xDirection < 0 && OnLeft) || (xDirection > 0 && !OnLeft))
            if (ballPos.x < 4.0f && ballPos.x > -4.0f && ballPos.y < -5.0f)
            {
                _direction = Vector2.up;
            }
            else if ((ballPos.x < 4.0f && ballPos.x > -4.0f && ballPos.y > 5.0f))
            {
                _direction = Vector2.down;
            }
            else if (offset > -1.5f && yDirection > 0)
            {
                _direction = Vector2.up;
            }
            else if (offset < 1.5f && yDirection < 0)
            {
                _direction = Vector2.down;
            }
            else
            {
                _direction = Vector2.zero;
            }
        else
        {
            GoToCenter();
        }
    }

    private void GoToCenter()
    {
        if (this.transform.position.y > 0.5f)
        {
            _direction = Vector2.down;
        }
        else if (transform.position.y < -0.5f)
        {
            _direction = Vector2.up;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
    
    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            Rigidbody.AddForce(_direction * this.speed);
        }
    }

    public void SetLevel(int level)
    {
        Level = level;
    }
}
