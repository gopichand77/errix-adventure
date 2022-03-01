using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerUnder : MonoBehaviour
{

    public int EnemyDamage;
    public int spikeDamge = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "Player")
        {
			var player = trig.GetComponent<PlayerController>();
            if (player.playerhurt.Damaged)
            {
                player.TakeDamage(EnemyDamage);

                player.playerhurt.Damaged = false;
            }
            player.playerhurt.knockCount = player.playerhurt.knockLenght;

            if (trig.transform.position.x < transform.position.x)
            {
                player.playerhurt.knockfromRight = true;
            }
            else
            {
                player.playerhurt.knockfromRight = false;
            }

        }
        if (trig.gameObject.tag == "Player")
        {
            var player = trig.GetComponent<PlayerController>();
            if (player.playerhurt.spikeDamaged)
            {
                player.TakeDamage(spikeDamge);
                player.playerhurt.spikeDamaged = false;
                player.horizontalSpeed = 8;
                player.VerticalSpeed = 8;

            }
            player.playerhurt.spikeKnockCount = player.playerhurt.knockLenght;
            player.playerhurt.spikeHurt = true;
        }
    }

}


