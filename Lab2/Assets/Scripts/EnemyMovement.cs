using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementDir;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float randX = Random.Range(-1.0f, 1.0f);
        float randY = Random.Range(-1.0f, 1.0f);

        float scale = 1.0f;
        scale = Random.Range(0.5f, 1.0f);
        rb.gameObject.transform.localScale = new Vector3( scale, scale, scale );

        movementDir = new Vector2(randX, randY);
        Vector3 movement = new Vector3(movementDir.x, 0.0f, movementDir.y);
        rb.velocity = movement * (speed * scale);
        // rb.AddForce(movement * speed);
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        // Vector3 movement = new Vector3(movementDir.x, 0.0f, movementDir.y);
        // rb.AddForce(rb.velocity * speed);
    }
}
