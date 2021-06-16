using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public int Bullets;
    public Button AttackButton;
    [Header("Variables")]
    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    
    public ParticleSystem dust;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        AttackButton.interactable = false;
        // moveSpeed;
    }


    private void Update()
    {
        Movement();
        checkAttackButton();


        
    }
    void checkAttackButton()
    {
        if(Bullets >  0)
        {
           AttackButton.interactable = true;
        }
        if(Bullets ==  0)
        {
           AttackButton.interactable = false;
        }
    }
    public void BulletHandler()
    {
        Bullets -=1;
    }
    void Movement()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") *moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)

            rb.AddForce(Vector2.up * 100f * jumpForce);
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
    }

    private void LateUpdate()
    {
        if(dirX  > 0 && !facingRight)
        {
            Flip();

        }
        else if(dirX < 0  && facingRight)
        {
            Flip();
        }
   
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
        CreateDust();

    }

    void CreateDust()
    {
        dust.Play();
    }

}