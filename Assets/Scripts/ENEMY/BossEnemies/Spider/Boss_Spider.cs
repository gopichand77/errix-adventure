using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spider : MonoBehaviour
{
   #region Public Variables
    public string attackName;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    [HideInInspector]public  Transform target;
    public int spiderHealth = 100;
    public BossHealth bossHealth;
    private int maxHealth = 100;
    [HideInInspector]public bool inRange; //Check if Player is in range
    public Transform leftLimit;
    public Transform rightLimit;
    public GameObject hotZone;
    public GameObject triggerArea;
    public Transform  FirePoint;
    public GameObject ThrowObject;
    
    
    

    #endregion

    #region Private Variables
    private int enemyDamage;
    private bool canShoot = true;
    public float shootTimer;
    public float shootCoolDown = 0.5f;
    bool canHurt = true;
    public bool Death = false;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    void Awake()
    {
        canHurt = true;
        bossHealth.SetMaxhealth(maxHealth);
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void Update () {
        
        if(spiderHealth <= 0)
        {
            Death = true;
            anim.SetBool("death",true);
           

        }
       if(!Death)
       {
            if(!attackMode)
        {
            Move();
        }
        if(!InsideLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Spider_attack") )
        {
            SelectTarget();

        }
        

        //When Player is detected
        
        if(inRange)
        {
            
           EnemyLogic(); 
        }
       }
	}

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > attackDistance)
        {
            
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

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(attackName))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not
        
        
         anim.SetBool("canWalk", false);
         Shoot();
         StartCoroutine(Animation());
        

}
IEnumerator Animation()
{
     yield return new WaitForSeconds(0.3f);
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

   

    public void TriggerCooling()
    {
        cooling = true;
    }
    
    private bool InsideLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x  < rightLimit.position.x;

    }
    public void SelectTarget()
    {
        if(!Death)
        {
            float distanceToLeft  =  Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        target =  distanceToLeft > distanceToRight ? leftLimit : rightLimit;
        // if(distanceToLeft > distanceToRight)
        // {
        // target = leftLimit; 
        // }
        // else
        // {
        //     target = rightLimit;
        // }
        Flip();
        }
    }
    public void Flip()
    {
        Vector3 rotation =  transform.eulerAngles;
    if(transform.position.x > target.position.x && !Death)
    {
        rotation.y = 180f;
    }
    else
    {
        rotation.y = 0f;
    }
      transform.eulerAngles =  rotation;
    }
    
     private void Shoot()
     {
       if(!Death)
       {
             shootTimer += Time.deltaTime;
         if(shootTimer >= shootCoolDown )
         {
             canShoot = true;
              
             shootTimer =  0;
         
         if(canShoot)
         {
             Vector2 Obj =  new Vector2(FirePoint.position.x,FirePoint.position.y+0.5f);
            GameObject thr =  (GameObject)Instantiate(ThrowObject,FirePoint.position,FirePoint.rotation);

             canShoot = false;
             TriggerCooling();
         }
         }
       }
     }
      public void TakeDamage(int damage) // The health is reduced in the bullet Script
    {
       
         spiderHealth -= damage;
         bossHealth.SetHealth(spiderHealth);
        //  StartCoroutine(Damage());


    }
    
     private void OnCollisionEnter2D(Collision2D trig)
     {
          if (trig.gameObject.tag == "Player" && !Death)
        {
            

            var player = GameObject.FindObjectOfType<Player>();
            if (player.playerhurt.Damaged)
            {
                player.TakeDamage(enemyDamage);
                player.MovementScript.anim.SetBool("isHurt", true);
                player.playerhurt.Damaged = false;
            }
            player.playerhurt.knockCount = player.playerhurt.knockLenght;

            if (trig.transform.position.x < transform.position.x)
            {
                player.playerhurt.knockfromRight = true
            ;
            }
            else
            {
                player.playerhurt.knockfromRight = false;
            }

        }
    }
   
     
}
