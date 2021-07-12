using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject GameOver;
    public int Keys;
    public int openChests;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private bool isGrounded;
    public int Bullets;
    public int goldCoins;
    public int gems;


    [Header("AttackButtons")]
    public Button AttackButton;
    public Button TreasureKey1;
    public Button TreasureKey2;
    public Button TreasureKey3;



    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public ParticleSystem dust;
    // public int health = 40;
    public float HurtForce = 30;
    // private bool canDoubleJump;

    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthSlider healthBar;


    [Header("KnockOut")]
    public float knockback;
    public float knockLenght;
    public float knockCount;
    public bool knockfromRight;
    public bool Damaged = false;

    [Header("spikeKnockOut")]
    public float spikeKnockback;
    public float spikeKnockLenght;
    public float spikeKnockCount;
    public bool spikeHurt = true;
    public bool spikeDamaged = true;



    //for score
    [Header("UI Elements")]
    public Text goldCoinScoreText;
    public Text gemsScoreText;
    public Text keysText;
    public Text treasureOpenedText;
    public Text noOfBulletsText;





    private void Start()
    {
        GameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        AttackButton.interactable = false;
        // moveSpeed;
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);

        //treasure reference 
        TreasureKey1.gameObject.SetActive(false);
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);
        //for score
        goldCoinScoreText.text = ""; //goldcoins
        gemsScoreText.text = ""; //gems
        keysText.text = ""; //keys
        treasureOpenedText.text = "";//Treasures opened
        noOfBulletsText.text = ""; //bullets

    }


    private void Update()
    {
        if (currentHealth <= 0)
        {
            new WaitForSeconds(1);
            GameOver.SetActive(true);
        }
        Movement();
        checkAttackButton();
        //for score
        goldCoinScoreText.text = "" + goldCoins;//working
        gemsScoreText.text = "" + gems;//not working
        keysText.text = "" + Keys;//working
        noOfBulletsText.text = "" + Bullets;// working
        treasureOpenedText.text = "" + openChests;
        //notworking treasure 
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

    IEnumerator GameTim()
    {
        yield return new WaitForSeconds(2);
        GameOver.SetActive(true);
    }

    public void BulletHandler()
    {
        Bullets -= 1;
    }
    void Movement()
    {
        // dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        // if (CrossPlatformInputManager.GetButtonDown("Jump"))
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || rb.velocity.y > -0.1 && rb.velocity.y < 0.1)
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



        if (rb.velocity.y == 0 || isGrounded)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 2 && !isGrounded)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", true);
            CreateDust();
        }
        if (rb.velocity.y < -1.2 && !isGrounded)
        {
            //these codes are for jumping and falling animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        hurtFromEnemy();
        hurtFromSpikes();


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

    //count score
    public void NoofGoldCoins()
    {
        goldCoins = goldCoins + 1;
    }
    public void NoOfAxes(int NoOfAxes1)
    {
        Bullets += NoOfAxes1;
    }
    public void NoofKeys(int NoofKeys1)
    {
        Keys += NoofKeys1;
    }
    public void OpenTreasure(int NoofCoins1)
    {
        Keys -= 1;
    }
    public void ChestOpen()
    {
        openChests = openChests + 1;
    }
    public void NoOfgems()
    {
        gems = gems + 1;
    }



    void Jump()
    {

        rb.AddForce(Vector2.up * 100f * jumpForce);


    }



    public void TakeDamage(int damage)
    {
        // health -= damage;
        StartCoroutine(Hurt());
        if (Damaged || spikeDamaged)
        {
            currentHealth -= damage;
            Damaged = false;
            spikeDamaged = false;
        }
        healthBar.SetHealth(currentHealth);
    }
    IEnumerator Hurt()
    {
        anim.SetBool("isFalling", false);

        anim.SetBool("isHurt", true);
        moveSpeed = 0;
        yield return new WaitForSeconds(0.8f);
        moveSpeed = 7;
        anim.SetBool("isHurt", false);


    }
    void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("greenGem"))
        {
            Destroy(trig.gameObject);

            NoOfgems();
        }
        if (trig.gameObject.CompareTag("Treasure"))
        {
            TreasureKey1.gameObject.SetActive(true);
            AttackButton.gameObject.SetActive(false);
            TreasureKey1.interactable = true;
        }

        if (trig.gameObject.CompareTag("Treasure2"))
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
        if (Keys == 0)
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
void hurtFromEnemy()
    {
        if (knockCount <= 0)
        {
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }

        else
        {
            if (knockfromRight)
            {
                rb.velocity = new Vector2(-knockback, rb.velocity.y);
                Damaged = true;



            }
            if (!knockfromRight)

                rb.velocity = new Vector2(knockback, rb.velocity.y);
            Damaged = true;


            knockCount -= Time.deltaTime;

        }
    }
     void hurtFromSpikes()
    {
        if (spikeKnockCount <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            if (spikeHurt)
            {
                spikeDamaged = true;
                rb.velocity = new Vector2(dirX, spikeKnockback);
                spikeKnockCount -= Time.deltaTime;
            }
        }

    }




}


