using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    
    public Animator anim;
    public float JumpForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * JumpForce);
            anim.Play("Jump");
        }
        
    }

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    // bool PlayerCollision(Collision2D collision)
    // {
    //     //When the player gets hurt this func() trigs and returns true 
    //     Player player = collision.gameObject.GetComponent<Player>();


    //     if (player != null && collision.contacts[0].normal.y < 0)
    //     {
             
           

    //         //animation and the return value for the player 
    //         return true;



    //     }
    //     else
    //     {

    //         // rb.velocity = new Vector2(HurtForce,rb.velocity.y);
    //         return false;
    //     }
    // }
    // private void OnCollisionStay2D(Collision2D collision)
    // {
        
    //     if (PlayerCollision(collision))
    //     {
    //         // PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, JumpForce);
    //         StartCoroutine(TrampJump());



    //     }
    // }
    // // private void OnCollisionExit2D(Collision2D collision)
    // // {
    // //     Player player = collision.gameObject.GetComponent<Player>();
    // //     if(!player)
    // //     {
    // //         anim.SetBool("Jump",false);

    // //     }
        
    
    // // private void OnCollisionSta(Collision2D collision)
    // // {//this triggers when the player shouldhurtfromcollision returns true

        
    // // }
    // // private void OnCollisionExit2D(Collision2D other)
    // // {
    // //      anim.SetBool("Jump", false);
    // // }
    // IEnumerator TrampJump()
    // {
    //      anim.SetBool("Jump",true);
    //      yield return new WaitForSeconds(0.3f);
    //      anim.SetBool("Jump",false);
    //     yield return new WaitForSeconds(0.3f);
    //     PlayerRb.velocity = transform.up * 15;
       
        
    // }


}
