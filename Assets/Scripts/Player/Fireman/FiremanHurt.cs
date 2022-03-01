using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanHurt : MonoBehaviour
{
    [SerializeField]
    PlayerController playerScript;
    [Header("KnockOut")]
    public float knockback;
    public float knockLenght;
    public float knockCount;
    public bool knockfromRight;
    internal bool Damaged = false;
    [Header("spikeKnockOut")]
    public float spikeKnockback;
    public float spikeKnockLenght;
    public float spikeKnockCount;
    
    internal bool spikeHurt = true;
    internal bool spikeDamaged = true;
    internal bool shotHurt = true;
    
    public bool isDead;
    public Collider2D playerCol;
    public Collider2D playerCol2;
    public Collider2D playerCol3;
    // public GameObject[] childObjs;
    public float shockForce;
    private Animator theAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        playerScript = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        
        // playerCol = GetComponent<Collider2D>();
        // playerCol2 = GetComponent<Collider2D>();
        // playerCol3 = GetComponent<Collider2D>();

    }
    private void FixedUpdate()

    {
        hurtFromEnemy();
        hurtFromSpikes();
    }
    void hurtFromSpikes()
    {
        if (spikeKnockCount <= 0)
        {
            playerScript.rb.velocity = new Vector2(playerScript.rb.velocity.x, playerScript.rb.velocity.y);
        }
        else
        {
            if (spikeHurt)
            {
                spikeDamaged = true;
                playerScript.rb.velocity = new Vector2(playerScript.dirX, spikeKnockback);
                spikeKnockCount -= Time.deltaTime;
               
            }
        }


    }
    void hurtFromEnemy()
    {
        if (knockCount <= 0)
        
        {
            
            playerScript.rb.velocity = new Vector2(playerScript.dirX, playerScript.rb.velocity.y);
        }

        else
        {
            if (knockfromRight)
            {
                
                playerScript.rb.velocity = new Vector2(-knockback, playerScript.rb.velocity.y);
                Damaged = true;

            }
            if (!knockfromRight)

                playerScript.rb.velocity = new Vector2(knockback, playerScript.rb.velocity.y);
            Damaged = true;
            knockCount -= Time.deltaTime;
           






        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
      
        if (trig.gameObject.CompareTag("Enemy"))
        {
            Damaged = true;
            
        }
        if (trig.gameObject.CompareTag("Traps"))
        {
            spikeDamaged = true;
            
        }
      
    }
    
  

}
