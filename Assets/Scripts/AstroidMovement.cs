using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody asteroidRb;
    private Vector3 initialTarget;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody>();
        initialTarget = (GameObject.Find("Player").transform.position - 
            transform.position).normalized;
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        asteroidRb.AddForce(initialTarget * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
