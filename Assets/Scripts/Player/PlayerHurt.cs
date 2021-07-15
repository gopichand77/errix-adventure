using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    //========================================================//
    // This the script for Player getting push back & Player Taking Damge From the player; //
    //There are two types of knockbacks
    //1.Enemy KnockBack
    //2.Spike KnockBack
    //This Script Takes Input from the enemy HurtPlayer Script and then knockBacks the Player 
    //The KnockBackLength is a Public variable.
    [SerializeField]
    Player playerScript;
    [Header("KnockOut")]
    public float knockback;
    public float knockLenght;
    public float knockCount;
    public bool knockfromRight;
    public bool Damaged = false;
    [Header("spikeKnockOut")]
    public float spikeKnockback;
    public float spikeKnockLenght;
    public float spikeKnockCount;
    public bool spikeHurt = true;
    public bool spikeDamaged = true;
    // Start is called before the first frame update
   
    private void FixedUpdate()
    {
        
        hurtFromEnemy();
        hurtFromSpikes();
    }
     void hurtFromSpikes()
    {
        if (spikeKnockCount <= 0)
        {
            playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.rb.velocity.x, playerScript.MovementScript.rb.velocity.y);
        }
        else
        {
            if (spikeHurt)
            {
                spikeDamaged = true;
                playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.dirX, spikeKnockback);
                spikeKnockCount -= Time.deltaTime;
            }
        }


    }
    void hurtFromEnemy()
    {
        if (knockCount <= 0)
        {
            playerScript.MovementScript.rb.velocity = new Vector2(playerScript.MovementScript.dirX, playerScript.MovementScript.rb.velocity.y);
        }

        else
        {
            if (knockfromRight)
            {
                playerScript.MovementScript.rb.velocity = new Vector2(-knockback, playerScript.MovementScript.rb.velocity.y);
                Damaged = true;



            }
            if (!knockfromRight)

                playerScript.MovementScript.rb.velocity = new Vector2(knockback, playerScript.MovementScript.rb.velocity.y);
            Damaged = true;


            knockCount -= Time.deltaTime;

        }
    }
}
