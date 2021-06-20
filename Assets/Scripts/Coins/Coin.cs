using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
    
      
        if(player!=null)
        {//animation and the return value for the player 
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
            Destroy(gameObject);
        }

    }
}
