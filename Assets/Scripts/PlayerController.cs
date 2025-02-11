using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizontalInput;
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        // camera view area
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        minX = (Camera.main.transform.position.x - halfWidth) + 1f;
        maxX = (Camera.main.transform.position.x + halfWidth) - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        bool allowMoveRight = transform.position.x <= maxX && horizontalInput > 0;
        bool allowMoveLeft = transform.position.x >= minX && horizontalInput < 0;

        if (allowMoveRight || allowMoveLeft)
        {
            transform.Translate(transform.right * Time.deltaTime * horizontalInput * speed);
        }


    }
}
