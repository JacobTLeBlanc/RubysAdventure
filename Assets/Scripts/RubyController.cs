using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5; // Max health of character
    public int health { get { return currentHealth; }}
    int currentHealth; // Var to keep track of current hp

    public float speed = 3.0f; // Speed of character

    Rigidbody2D rigidbody2d; // Rigidbody2d variable

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Get rb2d component of game object

        currentHealth = maxHealth; // Set health to full at start
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get set button from axes
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position; // Create var and set to our pos

        position.x = position.x + speed * horizontal * Time.deltaTime; // Update new pos if needed
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position); // Set our pos to new pos
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth); // Make sure health is between 0 and 5
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
