using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d; // Rigidbody2d variable

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get set button from axes
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position; // Create var and set to our pos

        position.x = position.x + 3.0f * horizontal * Time.deltaTime; // Update new pos if needed
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position); // Set our pos to new pos
    }
}
