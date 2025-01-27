using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_cooldown : MonoBehaviour
{
    [SerializeField]
    Enemy_Behaviour enemy_Behaviour;
     public int EnemyDamage;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {

            var player = collider2D.GetComponent<Player>();
            if (player.playerhurt.Damaged)
            {
                player.TakeDamage(EnemyDamage);
                player.MovementScript.anim.SetBool("isHurt", true);
                player.playerhurt.Damaged = false;
                Invoke("Wait",0.5f);
            }
            player.playerhurt.knockCount = player.playerhurt.knockLenght;

            if (collider2D.transform.position.x < transform.position.x)
            {
                player.playerhurt.knockfromRight = true
            ;
            }
            else
            {
                player.playerhurt.knockfromRight = false
            ;
            }

        }
    }
    void Wait()
    {
        enemy_Behaviour.TriggerCooling();
    }
}
