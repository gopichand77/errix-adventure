using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject Buttons;
    public int spikeDamge;


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            var player = collider2D.GetComponent<Player>();
            if (player.spikeDamaged)
            {
                player.TakeDamage(spikeDamge);
                player.anim.SetBool("isHurt", true);
                player.moveSpeed = 7;
                player.spikeDamaged = false;
            }
            player.spikeKnockCount = player.knockLenght;
            player.spikeHurt = true;
        }
    }

}
