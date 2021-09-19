using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour
{
 [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    Rigidbody2D rb;
   public Transform player;
    public float range;
    public float playerDist;


    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerDist = Vector2.Distance( player.transform.position, transform.position);
        if(range > playerDist)
        {
            anim.Play("Attack");
            moveSpeed = 0;
        }
        else
        {
            anim.StopPlayback();
            moveSpeed = 1;
            anim.Play("Move");
        }
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
                transform.localScale = new Vector2(-1, 1);
            
            
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
            ;
        }
        if (enemyParticleSys.Dead)
        {
            moveSpeed = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                
                movingRight = false;
            }
            else
            {
                
                movingRight = true;
            }
        }
    }
}
