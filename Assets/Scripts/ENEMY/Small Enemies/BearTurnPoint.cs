using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTurnPoint : MonoBehaviour
{
   [SerializeField]
    // EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    // public Animator anim;
    Rigidbody2D rb;
    Transform transform1;


    private void Start()
    {
        transform1  = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if (movingRight)
        {
            transform1.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform1.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform1.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform1.localScale = new Vector2(1, 1);
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

