using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHurt : MonoBehaviour
{
    //========================================================//
    // This the script for Player getting push back & Player Taking Damge From the player; //
    //There are two types of knockbacks
    //1.Enemy KnockBack
    //2.Spike KnockBack
    //This Script Takes Input from the enemy HurtPlayer Script and then knockBacks the Player 
    //The KnockBackLength is a Public variable.
    //=======================================================//
    [SerializeField]
    Player playerScript;
    [Header("KnockOut")]
    public float knockback;
    public float knockLenght;
    public float knockCount;
    internal bool knockfromRight;
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
    public GameObject[] childObjs;
    public float shockForce;
    private Animator theAnimator;
    private Rigidbody2D rb;



    public GameObject floatingDamage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();
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
            playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.rb.velocity.x, playerScript.MovementScript.rb.velocity.y);
        }
        else
        {
            if (spikeHurt)
            {
                spikeDamaged = true;
                playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.dirX, spikeKnockback);
                spikeKnockCount -= Time.deltaTime;
            }
        }


    }
    void hurtFromEnemy()
    {
        if (knockCount <= 0)
        
        {
            
            playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.dirX, playerScript.MovementScript.rb.velocity.y);
        }

        else
        {
            if (knockfromRight)
            {
                
                playerScript.MovementScript.rb.velocity = new Vector2(-knockback, playerScript.MovementScript.rb.velocity.y);
                Damaged = true;

            }
            if (!knockfromRight)

                playerScript.MovementScript.rb.velocity = new Vector2(knockback, playerScript.MovementScript.rb.velocity.y);
            Damaged = true;
            knockCount -= Time.deltaTime;







        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name.Contains("shot-1"))
        {
            shotHurt = true;
            GameObject damange = Instantiate(floatingDamage, transform.position, Quaternion.identity) as GameObject;
            damange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-10";
            playerScript.TakeDamage(10);
        }
        if (trig.gameObject.CompareTag("Enemy"))
        {
            Damaged = true;
            Invoke("Floating", 0.5f);
        }
        if (trig.gameObject.CompareTag("Traps"))
        {
            spikeDamaged = true;
            Invoke("Floating", 0.5f);
        }
        if(trig.gameObject.CompareTag("Water"))
        {
           PlayerDeath();

        }
    }
    void Floating()
    {
        GameObject damange = Instantiate(floatingDamage, transform.position, Quaternion.identity) as GameObject;
        damange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-10";
    }
    void PlayerDeath()
    {
        isDead = true;
        theAnimator.SetBool("Dead", true);
        playerScript.MovementScript.ctrlActive = false;
        playerCol.enabled = false;
        playerCol2.enabled =  false;
        playerCol3.enabled = false;
        foreach (GameObject child in childObjs)
            child.SetActive(false);
        rb.gravityScale = 2.5f;
        // rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * 100f * shockForce);
        playerScript.MovementScript.rb.velocity = new Vector2(0, 0);
        Destroy(gameObject,1.8f);
        

        
    }


}
