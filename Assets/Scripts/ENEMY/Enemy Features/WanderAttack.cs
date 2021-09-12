using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Greetings from Sid!

//Thank You for watching my tutorials
//I really hope you find my tutorials helpful and knowledgeable
//Appreciate your support.

public class WanderAttack : MonoBehaviour {

    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public bool canWalk = true;
   
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    internal GameObject target;
    private Animator anim;

    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    internal bool inRange; //Check if Player is in range
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    private Player player;
    private Vector2 value;
    
    #endregion

    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void FixedUpdate () {
        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            value = -Vector2.left;
            
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            value = Vector2.left;
        }
        
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, value, rayCastLength, raycastMask);
            RaycastDebugger();
            canWalk =  true;
            moveSpeed = 2f;
        }

        //When Player is detected
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
	}

    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if(trig.gameObject.tag == "Turn")
        {
            moveSpeed = 0;
            inRange = false;
            canWalk =  false;
            anim.SetBool("canWalk",false);
        }
        if(trig.gameObject.CompareTag("Bullet"))
        {
            Destroy(trig.gameObject);
            // anim.SetBool("hurt",true);
            

        }
        
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
       
         if(trig.gameObject.tag == "Turn")
        {
              canWalk = false;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance && canWalk)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(transform.position,value * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(transform.position, value * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
