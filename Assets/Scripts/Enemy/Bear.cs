using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public bool movingRight;
    public float moveSpeed = 0;
    public Transform Player;
    public float playerdist;
    public float EnemyRange;
    public float attackRange;
    public Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        playerdist = Vector2.Distance(transform.position, Player.position);
         if (playerdist < EnemyRange)
        {
            StartCoroutine(WakeUp());
            StartCoroutine(Walking());
        }
      
         if (playerdist < attackRange)
        {
            anim.SetBool("Attack",true);
            moveSpeed = 0;
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);

            // ChasePlayer();
            
            
            
        }
         if (playerdist > attackRange)
        {
            anim.SetBool("Attack",false);
            
           
           
            
        }
    //    ChasePlayer();
        
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
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
    IEnumerator WakeUp()
    {
        anim.SetBool("WakeUp", true);
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("WakeUp", false);
    }
    IEnumerator Walking()
    {
        yield return new WaitForSeconds(0.4f);
        moveSpeed = 2f;
        anim.SetBool("WakeUp",false);
        anim.SetFloat("Movement",moveSpeed);
    }
 
     void Flip()
    {
        
        transform.Rotate(0f, 180f, 0f);
      

    }

   // || Player.position.x < transform.position.x && transform.localScale.x  > 0
        
    }

