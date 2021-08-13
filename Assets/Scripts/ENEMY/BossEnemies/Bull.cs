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
    public bool  canHurt;
    public float bullHealth = 100f;
    public Transform player;
    public GameObject BossCollider;
    bool Died = false;
    public int damage;
    bool taunting;
    public bool WakeUp = false;
    public float moveSpeed;
    public float AttackTime;
    public float AttackCount;
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
        LookAtPlayer();
        
    }
      void LookAtPlayer()
    {
        AttackCount -= Time.deltaTime;
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if(taunting){
        transform.Translate(0, 0, 0);
        }
        else
        {
            transform.Translate(2*Time.deltaTime* -moveSpeed,0f,0f);

        }
        

        if (player.position.x - 3 > transform.position.x && !movingRight )
        {
            
            
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            movingRight = true;

            
        }

        if (player.position.x + 3 < transform.position.x && movingRight)
        {
           
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            movingRight = false;
        }
        if (playerdist < AttackRange && AttackCount <= 0)
        {
           
            anim.SetBool("Attack", true);
           moveSpeed =  moveSpeed *0f;
           

            

        }
        if (playerdist > AttackRange && WakeUp)
        {
            
            anim.SetBool("Attack", false);
            moveSpeed = 2f;
        }
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
                AttackCount = AttackTime;
                
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

            // bullHealth = bullHealth -5f;

        }
        if (trig.gameObject.CompareTag("Bullet") )//collisons 
        {
            
            Destroy(trig.gameObject);
            if(canHurt)
            {
                bullHealth -= 5;
            }

            

            if (bullHealth <= 0)
            {
                Died = true;

                anim.SetBool("Death",true);
                moveSpeed = 0f;
            }
            else
            {
                
                
            }

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
   
    IEnumerator Taunt()
    {
        taunting = true;
        moveSpeed = moveSpeed*0f;
        canHurt = false;
        // Attacking =  false;
        anim.SetBool("Attack",true);
        anim.SetBool("Chase", false);
        anim.SetBool("Taunt", true);
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Taunt", false);
        anim.SetBool("Chase", true);
        anim.SetBool("Attack",false);
        canHurt = true;
        // Attacking =  true;
        taunting = false;
        moveSpeed = 4f;
       
    }
 

}
