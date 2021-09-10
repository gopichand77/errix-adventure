using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
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
            
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            
        }
        if (enemyParticleSys.Dead)
        {
            moveSpeed = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                transform.Rotate(0f, 0f, 0f);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }
        }
    }
}
