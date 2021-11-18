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
        // Code from 2nd lesson
        float horizontal = Input.GetAxis("Horizontal"); // Gets horizontal input and stores in variable
        Debug.Log(horizontal);                          // Displays horizontal variable in debug log
        Vector2 position = transform.position;          // Created variable storing Ruby's position
        position.x = position.x + 0.1f * horizontal;    // Moves game object horizontally
        transform.position = position;                  // Sets game object's position to new value

        /* Original test code
        Vector2 position = transform.position;  // Created variable storing Ruby's position
        position.x = position.x + 0.1f;         // Moves game object to the right
        transform.position = position;          // Sets game object's position to new value
        */
    }
}
