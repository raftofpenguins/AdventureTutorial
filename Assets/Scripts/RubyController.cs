using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Added during World Interactions - Collectibles
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth;}} // Property used to access private int below
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    // My attempt at exposing player speed variable
    public float playerSpeed = 3.0f;

    //Added during World Interactions part 9
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    //Added during Sprite Animation tutorial
    Animator playerAnimator;
    Vector2 lookDirection = new Vector2(1,0);

    //Added during Projectile tutorial
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        //currentHealth = 1;

        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // Gets horizontal input and stores in variable
        vertical = Input.GetAxis("Vertical");     // Gets vertical input and stores in variable

        //Added during Sprite Animation tutorial
        Vector2 playerMove = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(playerMove.x, 0.0f) || !Mathf.Approximately(playerMove.x, 0.0f))
        {
            lookDirection.Set(playerMove.x, playerMove.y);
            lookDirection.Normalize();
        }

        playerAnimator.SetFloat("Look X", lookDirection.x);
        playerAnimator.SetFloat("Look Y", lookDirection.y);
        playerAnimator.SetFloat("Speed", playerMove.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //Added during Projectile tutorial
        if (Input.GetKeyDown(KeyCode.C))
        {
            LaunchCog();
        }

        // Code from 2nd lesson
        /*
        float horizontal = Input.GetAxis("Horizontal"); // Gets horizontal input and stores in variable
        float vertical = Input.GetAxis("Vertical");     // Gets vertical input and stores in variable
        */

        // Debug.Log(horizontal);                       // Displays horizontal variable in debug log

        // Moved to FixedUpdate during later tutorial
        /*
        Vector2 position = transform.position;          // Created variable storing Ruby's position
        position.x = position.x + 3.0f * Time.deltaTime * horizontal;    // Moves game object horizontally
        position.y = position.y + 3.0f * Time.deltaTime * vertical;      // Moves game object vertically

        transform.position = position;                  // Sets game object's position to new value
        */

        /* Original test code
        Vector2 position = transform.position;  // Created variable storing Ruby's position
        position.x = position.x + 0.1f;         // Moves game object to the right
        transform.position = position;          // Sets game object's position to new value
        */
    }

    // Added during World Interactions tutorial part 9
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;                                    // Created variable storing Ruby's position
        position.x = position.x + playerSpeed * Time.deltaTime * horizontal;        // Moves game object horizontally
        position.y = position.y + playerSpeed * Time.deltaTime * vertical;          // Moves game object vertically

        rigidbody2d.MovePosition(position);                                         // Sets game object's position to new value
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            
            playerAnimator.SetTrigger("Hit");
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void LaunchCog()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.LaunchCog(lookDirection, 300);

        playerAnimator.SetTrigger("LaunchCog");
    }

}
