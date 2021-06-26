using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour
{



    private Rigidbody2D rb;
    private Animator anim;
    public int Keys;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public int Bullets;
    public int Coins;
    private bool isGrounded;
    public Button AttackButton;
    public Button TreasureKey1;
    public Button TreasureKey2;
    public Button TreasureKey3;
    [Header("Variables")]
    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public ParticleSystem dust;
    // public int health = 40;
    public float HurtForce = 30f;
    // private bool canDoubleJump;
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealth healthBar;





    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        AttackButton.interactable = false;
        // moveSpeed;
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
        TreasureKey1.gameObject.SetActive(false);
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);

    }


    private void Update()
    {
        Movement();
        checkAttackButton();

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        Die();
    }
    void checkAttackButton()
    {
        if (Bullets > 0)
        {
            AttackButton.interactable = true;
        }
        if (Bullets == 0 || Bullets < 0)
        {
            AttackButton.interactable = false;
        }
    }
    public void BulletHandler()
    {
        Bullets -= 1;
    }
    void Movement()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        // dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        // if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
                // canDoubleJump = true;
            }
            // else if (canDoubleJump)
            // {
            //     // jumpForce = jumpForce / 1.5f;
            //     Jump();
            //     canDoubleJump = false;
            //     // jumpForce = jumpForce * 1.5f;
            // }
        }
        // anim.SetFloat("vertical", Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical")));//


        if (Mathf.Abs(dirX) > 0 && rb.velocity.y > -0.1 && rb.velocity.y < 0.1)
        {
            anim.SetBool("isRunning", true);

            // anim.SetFloat("vertical", 0);//
            CreateDust();

        }
        if (Mathf.Abs(dirX) == 0 && rb.velocity.y > -0.1 && rb.velocity.y < 0.1)
        {
            anim.SetBool("isRunning", false);
        }



        if (rb.velocity.y == 0)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 2)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", true);
            CreateDust();
        }
        if (rb.velocity.y < -1.2)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    private void LateUpdate()
    {
        if (dirX > 0 && !facingRight)
        {
            Flip();

        }
        else if (dirX < 0 && facingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        CreateDust();

    }

    void CreateDust()
    {
        dust.Play();
    }
    public void NoofCoins()
    {
        Coins += 1;
    }
    public void NoofKeys()
    {
        Keys += 1;
    }
    public void OpenTreasure()
    {
        Keys -= 1;
    }



    void Jump()
    {
        rb.AddForce(Vector2.up * 100f * jumpForce);
    }
    // bool ShouldHurtFromCollision(Collision2D collision)
    // {//When tge player gets hurt this func() trigs and returns true 
    //     Monster enemy = collision.gameObject.GetComponent<Monster>();

    //     if(enemy!=null && collision.contacts[0].normal.x < -0.5)
    //     {//animation and the return value for the player 
    //         anim.SetBool("isHurt",true);
    //         rb.velocity = new Vector2(-HurtForce,rb.velocity.y);

    //         return true;


    //     }
    //     else {
    //         anim.SetBool("isHurt",false);
    //        // rb.velocity = new Vector2(HurtForce,rb.velocity.y);
    //         return false;
    //     }
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {//this triggers when the player shouldhurtfromcollision returns true
    //     if (ShouldHurtFromCollision(collision))
    //     {
    //         TakeDamage(10);
    //         //animator.SetBool("isHurt",true);
    //      ]
    //         // animator.SetBool("isHurt",true);

    //     }

    // }


    public void TakeDamage(int damage)
    {
        // health -= damage;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
    void Die()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
         if (trig.gameObject.CompareTag("Treasure") )
        {
            TreasureKey1.gameObject.SetActive(true);
            AttackButton.gameObject.SetActive(false);
            TreasureKey1.interactable = true;
            
        }
        
         if (trig.gameObject.CompareTag("Treasure2") )
        {
            TreasureKey2.gameObject.SetActive(true);
            TreasureKey2.interactable = true;
            AttackButton.gameObject.SetActive(false);
            
        }
        
         if (trig.gameObject.CompareTag("Treasure3"))
        {

            TreasureKey3.gameObject.SetActive(true);
            TreasureKey3.interactable = true;
            AttackButton.gameObject.SetActive(false);
            
        }
        if(Keys == 0)
        {
            TreasureKey2.interactable = false;
        TreasureKey3.interactable = false;
       TreasureKey1.interactable = false;
            
        }
        
        
    }
   private void OnTriggerExit2D(Collider2D other)
   {

       
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);
       TreasureKey1.gameObject.SetActive(false);
        AttackButton.gameObject.SetActive(true);
       
   }
 

}


