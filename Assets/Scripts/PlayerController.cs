using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float minX;
    private float maxX;
    public GameObject projectilePrefab;

    void Start()
    {
        // Calculate the screen boundaries given the camera position and aspect ratio
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        minX = Camera.main.transform.position.x - halfWidth + 0.7f;
        maxX = Camera.main.transform.position.x + halfWidth - 0.7f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        WrapAround();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }



    /// <summary>
    /// Checks if the player is out of bounds and moves them to the other side of the screen
    /// </summary>
    private void WrapAround()
    {
        Vector3 position = transform.position;

        if (position.x > maxX)
        {
            position.x = minX;
        }
        else if (position.x < minX)
        {
            position.x = maxX;
        }

        transform.position = position;
    }
}
