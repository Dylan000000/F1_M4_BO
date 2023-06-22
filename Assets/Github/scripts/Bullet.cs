using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private Vector2 direction;

    void Start()
    {
        rb.velocity = direction.normalized * speed;
    }

    public void SetDirection(Vector2 bulletDirection)
    {
        direction = bulletDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject); // Destroy the bullet after it hits an enemy or any other collider
    }
}

