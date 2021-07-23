using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public bool movingRight;
    public bool playermovingRight;
    public float moveSpeed ;
    public Transform player;
    public float playerdist;
    public float EnemyRange;
    public float attackRange;
    public Rigidbody2D rb;
    public Animator anim;
    public bool PlayerRange = false;
    public bool run = false;
    // Start is called before the first frame update
   
   private void Start()
   {
       
       
   }
   private void Update()
   {
       playerdist = Vector2.Distance( player.transform.position, transform.position);
   }
    // Update is called once per frame
       private void FixedUpdate()
    {
          if(playerdist < EnemyRange)
        {
            PlayerRange = true;
        }
          if(playerdist > EnemyRange)
        {
            PlayerRange = false;
        }
        if(!run)
        {
            playermovingRight = false;
        }
        
        if(PlayerRange){
            if (playermovingRight)
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
        
        if(player.position.x  > transform.position.x )
        {
            if(PlayerRange && !run)
            {
           playermovingRight = false;
            }
        
        }
         if(player.position.x +3 < transform.position.x ) 
        {
            if(PlayerRange && run){
           
           playermovingRight = true;
            }
        
        }
        if(PlayerRange)
        {
            run = true;
        }
        if(!PlayerRange)
        {
            run = false;
        }
        if(player.position.x == transform.position.x)
        {
            anim.SetBool("WakeUp", false);
        }
        else
        {
            anim.SetBool("WakeUp", true);
        }
      
       
        
    }
    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.CompareTag("Turn"))
        {
          if(!run)
           
           {
                if(movingRight)
            {
                 movingRight = false;

            }
            else if(!movingRight )
            {
                movingRight = true;
            }
            
          
           }
        
        

        }

    }
    IEnumerator WakeUp()
    {
        anim.SetBool("WakeUp", true);
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("WakeUp", false);
    }
    IEnumerator Walking()
    {
        yield return new WaitForSeconds(0.4f);
        moveSpeed = 2f;
        anim.SetBool("WakeUp",false);
        anim.SetFloat("Movement",moveSpeed);
    }
 
     void Flip()
    {
        
        transform.Rotate(0f, 180f, 0f);
      

    }

   // || Player.position.x < transform.position.x && transform.localScale.x  > 0
        
    }

