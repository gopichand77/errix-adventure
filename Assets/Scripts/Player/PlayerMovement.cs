using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player playerScript;
    internal Rigidbody2D rb;
    public Animator anim;
    internal float dirX;
    internal bool dirY;
    internal bool facingRight = true;
    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    public LayerMask groundlayer;
    private ParticleSystem dust;
    public bool isGrounded;
    public float hangTime = 0.2f;
    public float hangCounter;
    public  bool ctrlActive = true;
    public bool canDoubleJump;
    public bool DoubleJump;

    // Start is called before the first frame update
    private void Start()
    {
        dust = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(ctrlActive)
        {
        Movement();
       

        }
        
        
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
    dirY = CrossPlatformInputManager.GetButtonDown("Jump");
    dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

    #elif UNITY_EDITOR__WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
    dirX = Input.GetAxis("Horizontal") * moveSpeed;
    dirY = Input.GetButtonDown("Jump");

a
    #endif
    // dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
    // dirY = CrossPlatformInputManager.GetButtonDown("Jump");
        if (dirY)

        {

        if (isGrounded)
        {
            

            Jump();

            canDoubleJump = true;
        }
        else if (canDoubleJump&& DoubleJump)
        {
            
            jumpForce = jumpForce / 2.5f;
            Jump();
            canDoubleJump = false;
            jumpForce = jumpForce * 2.5f;
        }
    }
        anim.SetFloat("vertical", Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical")));//


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


        if (rb.velocity.y > -0.1 && rb.velocity.y < 0.1 && isGrounded)
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
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collider") && rb.velocity.y < 2.5)
        {
            isGrounded = true;
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collider") && rb.velocity.y < 2.5)
        {
            isGrounded = true;
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
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

