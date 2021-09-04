using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Orange : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    private bool movingRight;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    public float playerDist;
    public float followRange;
    // public float attackRange;
    public bool follow;
    public bool playerRight;




    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerDist =  Vector2.Distance(player.position, transform.position);
        
        
    }

    private void FixedUpdate()
    {
        // if(player.position.x < followRange)
        // {
        //     follow = true;
        // }
        if (!follow)
        {
             if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        if (enemyParticleSys.Dead)
        {
            moveSpeed = 0;
        }
        }
        if(follow)
        {
            // if(player.transform.position.x > transform.position.x)
            // {
                
            //     transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);

            // }
            // else if(player.position.x > transform.position.x)
            // {
                
            //     transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);

            // }
            transform.position = Vector3.MoveTowards(player.position,transform.position , -moveSpeed * Time.deltaTime);


        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                
                movingRight = false;
            }
            else
            {
                
                movingRight = true;
            }
        }
    }
}
