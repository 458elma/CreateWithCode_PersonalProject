using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2000.0f;
    private float zBound = 5.0f;
    private float xBoundLeft = -10.0f;
    private float xBoundRight = -1.0f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        InBounds();
    }

    // Move player based on input, input adds forces to player
    void MovePlayer() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * horizontalInput * speed);
        playerRb.AddForce(Vector3.forward * verticalInput * speed);
    }

    // Invisible walls to keep player in game bounds
    void InBounds() {
        if (transform.position.z > zBound) {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y, zBound);
        }
        if (transform.position.z < -zBound) {
            transform.position = new Vector3(transform.position.x,
                transform.position.y, -zBound);
        }
        if (transform.position.x < xBoundLeft) {
            transform.position = new Vector3(xBoundLeft, 
                transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundRight) {
            transform.position = new Vector3(xBoundRight,
                transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroid")) {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")) {
            Destroy(other.gameObject);
        }
    }
}
