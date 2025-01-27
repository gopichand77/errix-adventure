using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    public GameObject shell;
    public GameObject snail;
    public bool Dead= false;
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
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
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
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
        
        if (trig.gameObject.CompareTag("Bullet"))
        {
            Shell();
            
        }
    }
    public void Shell()
    {
        if(!Dead)
        {
            Destroy(gameObject);
        Instantiate(shell,transform.position,Quaternion.identity);
        Instantiate(snail,transform.position,Quaternion.identity);
        Dead = true;
        }
    }
}
  // private void FixedUpdate()
    // {
    //   anim.PlayInFixedTime("Snail_running");
    // }