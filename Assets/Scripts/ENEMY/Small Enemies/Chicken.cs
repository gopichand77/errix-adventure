using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
  

    public bool isDead;
    public Collider2D Col1;
    public Collider2D Col2;
    private Material matDefault;
    SpriteRenderer spriteRenderer;
    private Material matWhite;
    public GameObject[] childObjs;
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    public int health = 20;
    public int damage;
    public bool damaged;
    public float shockForce;
    Rigidbody2D rb;
    Collider2D col2;

   


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
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
           spriteRenderer.material = matWhite;
            Invoke("ResetMaterial", 0.2f);
            damaged =  true;
            TakeDamage();
            if (health <= 0)
            {
               Invoke("Death",0.2f);

                
            }
            
    
        }
    
    }
     void TakeDamage()
    {
        if(damaged)
        {
            
            health -= damage;
             damaged = false;
        
        }
        
    }
     public void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }

    void Death()
    {
        isDead = true;
        anim.SetBool("Dead", true);

        Col1.enabled = false;
        Col2.enabled = false;

        foreach (GameObject child in childObjs)
            child.SetActive(false);
        rb.gravityScale = 2.5f;
        // rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * 100f * shockForce);
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject, 1.8f);



    }

}

