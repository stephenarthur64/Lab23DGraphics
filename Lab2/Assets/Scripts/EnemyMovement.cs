using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementDir;
    public float speed = 0;

    private static Dictionary<float, Color> scaleColors = new Dictionary<float, Color>
    {
        {0.5f, Color.green},
        {1.0f, Color.yellow},
        {1.5f, new Color(0.66f, 0.33f, 0.0f)},
        {2.0f, Color.red},
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float scale = 1.0f;
        int sizeType = Random.Range(0, 4);
        switch (sizeType) 
        {
            case 0:
                scale = 0.5f;
                speed *= scale;
                break;
            case 1:
                scale = 1.0f;
                break;
            case 2:
                scale = 1.5f;
                speed *= scale;
                break;
            case 3:
                scale = 2.0f;
                speed *= scale;
                break;

        }
        rb.gameObject.transform.localScale = new Vector3( scale, scale, scale );
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.material.color = scaleColors[scale];

        movementDir = Random.insideUnitCircle.normalized;

        Vector3 movement = new Vector3(movementDir.x * speed, 0.0f, movementDir.y * speed);
        rb.velocity = movement;
    }
}
