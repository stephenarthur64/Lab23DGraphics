using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementZ;

    public float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float scale = 1.0f;
        float scaleMod = 1.5f;

        float mass = 0.0f;
        float massMod = 0.1f;

        if (collision.gameObject.tag == "Enemy")
        { 
            mass = collision.rigidbody.mass * massMod;
            scale = collision.gameObject.transform.localScale.x * scaleMod;

            rb.mass += mass;
            rb.gameObject.transform.localScale = rb.gameObject.transform.localScale * scale;
            collision.gameObject.SetActive(false);

            Debug.Log(this.gameObject.transform.localScale);
        }
    }

}
