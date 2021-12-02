using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemySpeed = 2.0f;
    public float maxLoop = 2.0f;
    bool upOrDown = true;
    float loopDuration = 0.0f;

    Rigidbody2D enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loopDuration < maxLoop)
            loopDuration += Time.deltaTime;
        else
        {
            upOrDown = !upOrDown;
            loopDuration = 0;
        }

        //Debug.Log(loopDuration);
    }

    void FixedUpdate()
    {
        Vector2 enemyPosition = enemyRigidbody.position;

        if (upOrDown == true)
        {
            enemyPosition.y = enemyPosition.y + enemySpeed * Time.deltaTime;
            enemyRigidbody.MovePosition(enemyPosition);
        }
        else
        {
            enemyPosition.y = enemyPosition.y - enemySpeed * Time.deltaTime;
            enemyRigidbody.MovePosition(enemyPosition);
        }

        //Debug.Log(enemyPosition.y);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Object that entered trigger: " + other);

        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        
    }
}
