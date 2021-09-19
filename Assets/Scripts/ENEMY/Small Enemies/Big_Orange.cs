using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Orange : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    private bool movingRight;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    public Transform rayCast;
    
    public float playerDist;
    public float followRange;
    // public float attackRange;
    public bool follow;
    public bool playerRight;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        
        
    }
    private void FixedUpdate()
    {
        playerDist =  Vector2.Distance(player.position, transform.position);
        if(canSeePlayer(followRange))
        {
            ChasePlayer();
        }
        else
        {
            // StopChasingPlayer();
            
        }
    }
    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed,0);
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed,0);
            transform.localScale = new Vector2(-1,1);

        }
    }
    void StopChasingPlayer()
    {
        rb.velocity =  new Vector2(0,0);
    }

    bool canSeePlayer(float distance)
    {
        bool val =  false;
        float castDist = distance;

        Vector2 endPos = rayCast.position +  Vector3.right * distance;

        RaycastHit2D hit = Physics2D.Linecast(rayCast.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider !=  null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(rayCast.position, endPos, Color.blue);
        }
        return val;

    }

  
}
