using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player playerScript;
    public Rigidbody2D rb;
    public Animator anim;
    internal float dirX;
    internal bool dirY;
    internal bool facingRight = true;
    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public ParticleSystem dust;
    internal bool isGrounded;
    // Start is called before the first frame update
      private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       

    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
     void Movement()
    {
        #if UNITY_EDITOR
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetButtonDown("Jump");

        #elif UNITY_ANDROID
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetButtonDown("Jump");

        #elif UNITY_IOS
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        dirY = CrossPlatformInputManager.GetButtonDown("Jump");
        #endif
        if (dirY)
        {
            if (isGrounded && rb.velocity.y > -0.1 && rb.velocity.y < 0.5)
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



        if (rb.velocity.y > -0.1 && rb.velocity.y < 0.1 || isGrounded)
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
        


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }
    void Jump()
    {

        rb.AddForce(Vector2.up * 100f * jumpForce);


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

}

