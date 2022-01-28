using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool movingRight = false;
    [SerializeField]
    float playerdist;
    
    public float EnemyRange;


    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        Player = GameObject.FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerdist = Vector2.Distance(transform.position, Player.position);
        if (playerdist < EnemyRange)
        {
            moveSpeed = -2f;
        }
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        if (playerdist > EnemyRange)
        {
            
            moveSpeed = 0f;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player =  collision.gameObject.GetComponent<Player>();
        {
            if(player)
            {
                Destroy(player.gameObject);
            }
        }
        
    }
}