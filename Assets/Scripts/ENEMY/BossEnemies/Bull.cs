using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    bool movingRight;
    float playerdist;
    public float ChaseRange;
    public float AttackRange;
    public bool canHurt;
    public List<GameObject> Boxes;
    public List<ParticleSystem> Winners;
    public bool Attacking;
    

    public int bullHealth = 100;
    public Transform player;
    public GameObject BossCollider;
    public bool Died = false;
    public int damage;
    bool taunting;
    public bool WakeUp = false;
    float moveSpeed;
    
    // public float Speed;
    public int EnemyDamage;
    public List<BoxCollider2D> boxColliders;
    public BullHealth bullHealthScript; //health bar ui
    [SerializeField]
    GameObject bossFightImage;
     [Header("Health")]
    public int maxHealth = 100;
    // public int currentHealth;

    void Start()
    {
        Attacking = true;
        
        canHurt = true;
        bullHealth = maxHealth;
        moveSpeed = 0f;
        bullHealthScript.SetMaxhealth(maxHealth);
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
            bossFightImage.SetActive(true);
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
        if (!Died)
        {

            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;
            if (taunting)
            {
                transform.Translate(0, 0, 0);
            }
            else
            {
                transform.Translate(2 * Time.deltaTime * -moveSpeed, 0f, 0f);

            }


            if (player.position.x - 3 > transform.position.x && !movingRight)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }

            if (player.position.x + 3 < transform.position.x && movingRight)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;
            }
            if(Attacking)
            {
            if (playerdist < AttackRange )
            {
                taunting = true;
                anim.SetBool("Chase",false);
                anim.SetBool("Attack", true);
            }
                
        }
            
            if (playerdist > AttackRange && WakeUp)
            {
                anim.SetBool("Attack", false);
                moveSpeed = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (!Died)
        {
            if (trig.gameObject.tag == "Player")
            {

                var player = trig.GetComponent<Player>();
                if (player.playerhurt.Damaged )
                {
                    Attacking = false;
                    player.TakeDamage(EnemyDamage);
                    player.MovementScript.anim.SetBool("isHurt", true);
                    player.playerhurt.Damaged = false;
                    StartCoroutine(idle());
                    
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
            if (trig.gameObject.CompareTag("Bullet"))//collisons 
            {

                Destroy(trig.gameObject);
                if (canHurt)
                {
                    TakeDamage();
                   
                    
                }
                if (bullHealth <= 0)
                {
                    Died = true;

                    anim.SetBool("Death", true);
                    moveSpeed = moveSpeed * 0f;
                    foreach (GameObject box in Boxes)
                    {
                        box.SetActive(false);
                    }
                    foreach (ParticleSystem win in Winners)
                    {
                        win.Play();
                    }
                    foreach (BoxCollider2D collider in boxColliders)
                    {
                        collider.enabled = false;
                    }
                    } 
                    
                



                

            }
        }
    }
    void TakeDamage()
    {
         bullHealth -= 5;
         bullHealthScript.SetHealth(bullHealth);
         StartCoroutine(Damage());


    }
    IEnumerator idle()
        {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Attack", false);
        taunting = true;
        canHurt = false;
        Attacking =  false;
        anim.SetBool("idle", true);
        anim.SetBool("Chase", false);
        yield return new WaitForSeconds(1f);
        anim.SetBool("idle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("PlayerRange", true);
        
        Attacking = true;
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("PlayerRange", false);
        anim.SetBool("idle", false);
        anim.SetBool("Chase", true);
        
        
        taunting = false;
        
        canHurt = true;


        }
    
    
    IEnumerator Damage()
    {
        taunting =  true;
         anim.SetBool("Damage",true);
         yield return new WaitForSeconds(0.5f);
         anim.SetBool("Damage", false);
         taunting = false;
         
        
    }

    IEnumerator PlayerInRange()
    {
        taunting = true;
        anim.SetBool("PlayerRange", true);
        yield return new WaitForSeconds(1f);
        taunting = false;
        anim.SetBool("PlayerRange", false);
        moveSpeed = 4f;

        anim.SetBool("Chase", true);
    }

    


}
