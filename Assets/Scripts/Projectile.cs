using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D cogRigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        cogRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchCog(Vector2 direction, float force)
    {
        cogRigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile collided with " + other.gameObject);
        Destroy(gameObject);
    }
}
