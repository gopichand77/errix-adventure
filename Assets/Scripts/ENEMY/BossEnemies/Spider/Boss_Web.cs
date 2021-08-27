using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Web : MonoBehaviour
{
     public float speed;
    Rigidbody2D rb;
    Animator anim;
    Player player;
    public int damage;
    public bool isHurt;
    
    Boss_Spider spider;
   
       // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(Speed());
        spider = GameObject.FindObjectOfType<Boss_Spider>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
        
    }
    IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = transform.right *speed;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Collider"))
        {
              rb.velocity = transform.right * 0;
              anim.SetBool("isDestroyed", true);
              Destroy(gameObject,0.5f);
        }
         if(trig.gameObject.CompareTag("Player") && !isHurt)
        {
            isHurt = true;

            rb.velocity = transform.right * 0;
            rb.isKinematic =  true;
            
            StartCoroutine(Damage());
            Invoke("CanHurt",3);
            spider.TriggerCooling();

              
              
        }
    }
    void CanHurt()
    {
        isHurt = false;


    }

    IEnumerator Damage()
    {
        if(isHurt)
        {
            // player.MovementScript.ctrlActive = false;
            player.MovementScript.moveSpeed =  player.MovementScript.moveSpeed*0f;
            player.MovementScript.jumpForce = 0f;

        StartCoroutine(Destroy());
        player.playerhurt.Damaged =  true;
        player.TakeDamage(10);
         
        
        }
        yield return new WaitForSeconds(3f);
        isHurt = false;
    }
    IEnumerator Destroy()
    {
       yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        player.MovementScript.ctrlActive = true;
        player.MovementScript.moveSpeed = 7f;
            player.MovementScript.jumpForce = 7f;
//             player.MovementScript.moveSpeed = 7f;
//             // player.MovementScript.rb.velocity = player.MovementScript.rb.velocity + 7f;
// player.MovementScript.rb.velocity = new Vector2(player.MovementScript.dirX, player.MovementScript.rb.velocity.y);
       

        
    }
}
