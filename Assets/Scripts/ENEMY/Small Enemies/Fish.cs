using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
   [SerializeField]
    // EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    // public Animator anim;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
        // if(trig.gameObject.CompareTag("Player"))
        // {
        //     gameObject.SetActive(false);
        // }
    }
}
