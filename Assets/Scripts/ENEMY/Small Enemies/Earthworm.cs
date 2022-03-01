using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthworm : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    // public Animator anim;
    Rigidbody2D rb;
    LayerMask layer;
    internal Player player;
    


    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
       
        gameObject.layer = LayerMask.NameToLayer("Earthworm");
    }

    private void FixedUpdate()
    {
        // Physics2D.IgnoreCollision(player.GetComponent)
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
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
    private void OnCollisionEnter2D(Collision2D  col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        }
    }
}
