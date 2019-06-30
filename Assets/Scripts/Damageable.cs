using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
   void OnTriggerStay2D(Collider2D other)
    {
        // Get Ruby Script as a variable
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);    
        }
    }
}
