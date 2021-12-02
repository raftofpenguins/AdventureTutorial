using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemySpeed = 2.0f;
    public float maxLoop = 2.0f;
    bool upOrDown = true;
    bool leftOrRight = true;
    bool moveVertically = true;
    float loopDuration = 0.0f;
    int moveCycle = 0;

    Rigidbody2D enemyRigidbody;

    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loopDuration < maxLoop)
            loopDuration += Time.deltaTime;
        else
        {
            upOrDown = !upOrDown;
            leftOrRight = !leftOrRight;
            loopDuration = 0;

            if (moveCycle < 1) {
                moveCycle += 1;
            } else {
                moveVertically = !moveVertically;
                moveCycle = 0;
            }
        }

        //Debug.Log("moveCycle: " + moveCycle + " | moveVertically: " + moveVertically);
    }

    void FixedUpdate()
    {
        Vector2 enemyPosition = enemyRigidbody.position;

        if (moveVertically == true) {
            if (upOrDown == true)
            {
                enemyAnimator.SetFloat("Move X", 0);
                enemyAnimator.SetFloat("Move Y", 1);
                enemyPosition.y = enemyPosition.y + enemySpeed * Time.deltaTime;
                enemyRigidbody.MovePosition(enemyPosition);
            }
            else
            {
                enemyAnimator.SetFloat("Move X", 0);
                enemyAnimator.SetFloat("Move Y", -1);
                enemyPosition.y = enemyPosition.y - enemySpeed * Time.deltaTime;
                enemyRigidbody.MovePosition(enemyPosition);
            }
        } else {
            if (leftOrRight == true)
            {
                enemyAnimator.SetFloat("Move X", 1);
                enemyAnimator.SetFloat("Move Y", 0);
                enemyPosition.x = enemyPosition.x + enemySpeed * Time.deltaTime;
                enemyRigidbody.MovePosition(enemyPosition);
            }
            else
            {
                enemyAnimator.SetFloat("Move X", -1);
                enemyAnimator.SetFloat("Move Y", 0);
                enemyPosition.x = enemyPosition.x - enemySpeed * Time.deltaTime;
                enemyRigidbody.MovePosition(enemyPosition);
            }
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
