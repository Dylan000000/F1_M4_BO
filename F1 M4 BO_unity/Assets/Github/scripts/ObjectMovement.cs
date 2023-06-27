using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float followSpeed = 5f;
    public Transform player;

    private bool isMovingRight = true;

    private void Update()
    {
        // Move the object horizontally (left to right)
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collided with a wall
        if (other.CompareTag("Wall"))
        {
            isMovingRight = !isMovingRight; // Reverse the movement direction
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            isMovingRight = !isMovingRight; // Reverse the movement direction
        }
    }
}