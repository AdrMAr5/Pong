using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength = 5.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            if (normal.y / normal.x > 20)
            {
                normal.y *= 0.75f;
            }
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
