using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public bool movingRight;
    public float playerdist;
    public float ChaseRange;
    public float AttackRange;
    public float bullHealth = 100f;
    public Transform player;
    public GameObject BossCollider;
    bool Died = false;
    bool taunting;
    public bool WakeUp = false;
    public float moveSpeed;
    public bool Attacking;
    public int EnemyDamage;
    public BullHealth bullHealthScript; //health bar ui

    void Start()
    {
        moveSpeed = 0f;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerdist = Vector2.Distance(transform.position, player.position);
        if (playerdist < ChaseRange && !WakeUp)
        {
            StartCoroutine(PlayerInRange());
            WakeUp = true;

            BossCollider.SetActive(true);


        }
        if (bullHealth == 0f)
        {
            BossCollider.SetActive(false);
            Died = true;
            // bullHealthScript.
            // bullHealth.SetHealth(0,0);//health bar ui

        }

    }
    private void FixedUpdate()
    {
        if (movingRight)
        {
            if (!taunting)
            {
                transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            }
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            if (!taunting)
            {
                transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            }
            transform.localScale = new Vector2(1, 1);
        }

        if (player.position.x - 3 > transform.position.x)
        {
            movingRight = false;
        }

        if (player.position.x + 3 < transform.position.x)
        {
            movingRight = true;
        }
        if (playerdist < AttackRange)
        {
            Attacking = true;
            anim.SetBool("Attack", true);
            moveSpeed = moveSpeed * 0f;
        }
        if (playerdist > AttackRange && WakeUp)
        {
            Attacking = false;
            anim.SetBool("Attack", false);
            moveSpeed = 2f;
        }
    }
    IEnumerator PlayerInRange()
    {
        taunting = true;
        anim.SetBool("PlayerRange", true);
        yield return new WaitForSeconds(1f);
        taunting = false;
        anim.SetBool("PlayerRange", false);
        moveSpeed = 2f;

        anim.SetBool("Chase", true);
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {

            var player = trig.GetComponent<Player>();
            if (player.playerhurt.Damaged)
            {
                player.TakeDamage(EnemyDamage);
                player.MovementScript.anim.SetBool("isHurt", true);
                player.playerhurt.Damaged = false;
                StartCoroutine(Taunt());
            }
            player.playerhurt.knockCount = player.playerhurt.knockLenght;

            if (trig.transform.position.x < transform.position.x)
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
        if (trig.gameObject.tag == "Turn")
        {
            moveSpeed = 0f;

            bullHealth = bullHealth -5f;

        }
    }

    IEnumerator Taunt()
    {
        taunting = true;
        moveSpeed = 0f;
        anim.SetBool("Chase", false);
        anim.SetBool("Taunt", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Taunt", false);
        anim.SetBool("Chase", true);
        taunting = false;
        moveSpeed = 4f;
        if(bullHealth < 100f){
            // bullHealth = bullHealth + 10f;
        }
    }


}
