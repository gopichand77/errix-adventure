using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    Rigidbody2D rb;
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    [SerializeField]
    public Transform Player;
    float playerdist;
    public float attackRange;

    // bool _hasDied;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerdist = Vector2.Distance(transform.position, Player.position);
        if (playerdist < attackRange)
        {
            anim.SetBool("Attack", true);

        }
        if (playerdist > attackRange)
        {
            anim.SetBool("Attack", false);


        }


    }
    private void FixedUpdate()
    {
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

    // IEnumerator Die()
    // {
    //     // _hasDied = true;
    //     moveSpeed = 0;
    //     anim.SetBool("isHurt", true);
    //     yield return new WaitForSeconds(0.2f);
    //     gameObject.SetActive(false);
    // }


}


