using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreRef;

    private Rigidbody rb;
    private float movementX;
    private float movementZ;

    public float scaleMod = 1.0f;
    public float massMod = 1.0f;
    public float scaleModNegative;
    public float scaleMin = 0.2f;

    private float score = 0.0f;

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
        rb.gameObject.transform.localScale -= new Vector3(scaleModNegative, scaleModNegative, scaleModNegative);
        Debug.Log(rb.gameObject.transform.localScale);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movement * speed);
        if (rb.gameObject.transform.localScale.x <= scaleMin)
        {
            this.gameObject.SetActive(false);
        }
    }

    void EnemyEaten(Collision collision)
    {
        float scale = 1.0f;
        float mass = 0.0f;

        mass = collision.rigidbody.mass * massMod;
        scale = collision.gameObject.transform.localScale.x * scaleMod;

        scale = Mathf.Clamp(scale, 1.1f, 20.0f);

        score += collision.gameObject.transform.localScale.x * 10;
        scoreRef.text = "Score: " + score.ToString();

        rb.mass += mass;
        rb.gameObject.transform.localScale = rb.gameObject.transform.localScale * scale;
        speed *= scale;
        collision.gameObject.SetActive(false);

        Debug.Log(this.gameObject.transform.localScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.transform.localScale.x <= transform.localScale.x)
            {
                EnemyEaten(collision);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
