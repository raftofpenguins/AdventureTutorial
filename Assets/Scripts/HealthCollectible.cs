using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Object that entered trigger: " + other);

        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            // Added condition to check if HP is full
            if(controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
