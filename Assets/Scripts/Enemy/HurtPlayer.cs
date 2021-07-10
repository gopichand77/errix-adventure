using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int EnemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
        {
            
            var player =  collider2D.GetComponent<Player>();
            if(player.Damaged)
            {
                player.TakeDamage(EnemyDamage);
                player.anim.SetBool("isHurt",true);
                player.Damaged = false;
            }
            player.knockCount = player.knockLenght;

            if(collider2D.transform.position.x  < transform.position.x)
            player.knockfromRight = true;
            else
            player.knockfromRight =  false;

        }
    }
}