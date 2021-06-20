using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D PlayerRb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     bool PlayerCollision(Collision2D collision)
    {//When tge player gets hurt this func() trigs and returns true 
        Player player = collision.gameObject.GetComponent<Player>();
     
      
        if(player!=null && collision.contacts[0].normal.y < 0 )
        {
           anim.SetBool("Jump",true);
       
            //animation and the return value for the player 
            return true;

            
            
        }
        else {
            
           // rb.velocity = new Vector2(HurtForce,rb.velocity.y);
            return false;
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {//this triggers when the player shouldhurtfromcollision returns true
    
      if (PlayerCollision(collision))
      {
           StartCoroutine(TrampJump());
           

      }
      else
      {
           anim.SetBool("Jump",false);

      }
           }
           IEnumerator TrampJump()
           {
               yield return new WaitForSeconds(0.1f);
               PlayerRb.velocity = new Vector2(PlayerRb.velocity.x,15f);

           }
}
