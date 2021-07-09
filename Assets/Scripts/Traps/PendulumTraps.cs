using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumTraps : MonoBehaviour
{
    Rigidbody2D rb2d;


    private void OnCollisionEnter2D(Collision2D collison)
    {
         Player player = collison.gameObject.GetComponent<Player>();
        if(player.currentHealth > 30)
        {
            player.TakeDamage(30);
        }
        if(player.currentHealth == 10)
        {
            player.TakeDamage(10);
        }
        if( player.currentHealth == 20)
        {
            player.TakeDamage(20);

        }
        if(player.currentHealth < 1)
        {
            Destroy(player.gameObject);

        }
        
 
    }
}