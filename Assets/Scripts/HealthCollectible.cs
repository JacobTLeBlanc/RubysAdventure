using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem healthEffect;
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Get Ruby Script as a variable
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Instantiate(healthEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                controller.PlaySound(collectedClip);
            }    
        }
    }
}
