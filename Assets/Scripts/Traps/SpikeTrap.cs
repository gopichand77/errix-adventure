using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject controlCanvas;
    public int spikeDamge = 10;

    private void Start()
    {
        controlCanvas =  GameObject.Find("Controls Panel");
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            var player = collider2D.GetComponent<Player>();
            if (player.playerhurt.spikeDamaged)
            {
                player.TakeDamage(spikeDamge);
                player.playerhurt.spikeDamaged = false;
                player.MovementScript.anim.SetBool("isHurt",true);
                player.MovementScript.anim.SetBool("isFalling",false);
                player.MovementScript.moveSpeed = 7;
                
            }
            player.playerhurt.spikeKnockCount = player.playerhurt.knockLenght;
            player.playerhurt.spikeHurt = true;
        }
    }

}