using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
       [SerializeField]
    EnemyParticleSys enemyParticleSys;
    
    public bool isDead;
    public Collider2D playerCol;
    public Collider2D playerCol2;
    public GameObject[] childObjs;
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    public float shockForce;
    Rigidbody2D rb;
    Collider2D col2;


    private void Start()
    {
       col2 = this.gameObject.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
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
         if (trig.gameObject.CompareTag("Bullet"))//collisons 
        {
            
            Destroy(trig.gameObject);
           Invoke("PlayerDeath", 0.2f);
            // else
            // {
                
            //     Invoke("ResetMaterial", 0.2f);
            // }

        }
    }
    void PlayerDeath()
    {
        isDead = true;
        anim.SetBool("Dead", true);
        
        playerCol.enabled = false;
        playerCol2.enabled =  false;
        
        foreach (GameObject child in childObjs)
            child.SetActive(false);
        rb.gravityScale = 2.5f;
        // rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * 100f * shockForce);
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject,1.8f);
        

        
    }
     
}

