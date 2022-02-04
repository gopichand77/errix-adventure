using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_wander : MonoBehaviour
{
    [SerializeField]
    // EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    // public Animator anim;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
     
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("Entered");
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
    //  void OnTriggerExit2D(Collider2D trig)
    // {
    //     if(trig.gameObject.CompareTag("Turn"))
    //     {
    //         if(movingRight)
    //         {
    //             movingRight = false;
    //         }
    //         else
    //         {
    //             movingRight = true;

    //         }
    //     }
    // }
}