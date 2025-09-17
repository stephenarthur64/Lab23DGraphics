using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementDir;
    private int speed = 0;

    public float scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float randX = Random.Range(-1.0f, 1.0f);
        float randY = Random.Range(-1.0f, 1.0f);
        speed = Random.Range(5, 10);

        scale = Random.Range(0.5f, 1.0f);
        rb.gameObject.transform.localScale = new Vector3( scale, scale, scale );

        movementDir = new Vector2(randX, randY);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementDir.x, 0.0f, movementDir.y);
        rb.AddForce(movement * speed);
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }
}
