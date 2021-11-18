using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;  //Created variable storing Ruby's position
        position.x = position.x + 0.1f;         // Moves game object to the right
        transform.position = position;          // Sets game object's position to new value
    }
}
