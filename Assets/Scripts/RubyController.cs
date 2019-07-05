using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5; // Max health of character
    public int health { get { return currentHealth; }} // Get method (property)
    int currentHealth; // Var to keep track of current hp

    public float timeInvicible = 2.0f;
    bool isInvicible;
    float invicibleTimer;

    public float speed = 3.0f; // Speed of character

    Rigidbody2D rigidbody2d; // Rigidbody2d variable
    Animator animator; // Animator 
    Vector2 lookDirection = new Vector2(1,0); // Current direction
    public GameObject projectilePrefab;
    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Get rb2d component of game object
        animator = GetComponent<Animator>();

        currentHealth = maxHealth; // Set health to full at start
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get set button from axes
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        // Check if moving
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            // Set direction of character
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize(); // Normalize vector
        }

        animator.SetFloat("Look X", lookDirection.x); // Set animation settings
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position; // Create var and set to our pos

        position = position + move * speed * Time.deltaTime; // New pos

        rigidbody2d.MovePosition(position); // Set our pos to new pos

        if (isInvicible)
        {
            invicibleTimer -= Time.deltaTime;
            if (invicibleTimer < 0)
            {
                isInvicible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0) 
        {
            if (isInvicible)
            {
                return;
            }
            
            animator.SetTrigger("Hit");
            isInvicible = true;
            invicibleTimer = timeInvicible;
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth); // Make sure health is between 0 and 5
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}
