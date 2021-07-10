using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject Buttons;
    public int spikeDamge;
    // Start is called before the first frame update
  
    // bool PlayerCollision(Collision2D collision)
    // {//When tge player gets hurt this func() trigs and returns true 
    //     Player player = collision.gameObject.GetComponent<Player>();
    
      
    //     if(player!=null)
    //     {
    //         //animation and the return value for the player 
    //         return true;
            
            
    //     }
    //     else {
            
    //        // rb.velocity = new Vector2(HurtForce,rb.velocity.y);
    //         return false;
    //     }
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {//this triggers when the player shouldhurtfromcollision returns true
    
    //     if (PlayerCollision(collision))
    //     {
    //         StartCoroutine(Die(collision));
    //     }
    // }
    // IEnumerator Die(Collision2D collision)
    
    // {
    //     Player player = collision.gameObject.GetComponent<Player>();
    //     yield return new WaitForSeconds(1f);
    //    player.gameObject.SetActive(false);
    // //    Buttons.gameObject.SetActive(false); Game Over
    // }
       
         private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
        {
            
            var player =  collider2D.GetComponent<Player>();
            if(player.SPIKEDamaged)
            {
                player.TakeDamage(spikeDamge);
                player.anim.SetBool("isHurt",true);
                player.moveSpeed = 7;
                player.SPIKEDamaged = false;
            }
            player.SPIKEknockCount = player.knockLenght;
            player.SPIKEhurt = true;

            
            
            
           

        }
    }
    
}
