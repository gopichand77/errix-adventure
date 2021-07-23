using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoEnemy : MonoBehaviour
{
    public float Speed;
    float horizontalSpeed;
    public bool vertical;
    public float VerticalSpeed;
    public float amplitude;
    public float desiredPostionY;
    public bool movingRight;
    
    public Vector3 tempPosition;
    private Animator anim;
    [SerializeField]
    Player player;
    float playerDist;
    public float startRange;
    public float rangeOfFire;
    float fireRate = 0.3f;
     float nextFire;
    [SerializeField]
    GameObject Shot;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Speed = 0;
        VerticalSpeed = 0;
        tempPosition = transform.position;
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
     
        
        playerDist = Vector2.Distance(player.transform.position,transform.position);

        
         if(playerDist < startRange)
        {
            StartCoroutine(StartUfo());
        if(playerDist < rangeOfFire)
        {
            checkFireTime();
        }
        }
         tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude + desiredPostionY;
        transform.position = tempPosition;
        if (movingRight)
        {
            horizontalSpeed = Speed;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {

            horizontalSpeed = -Speed;
            transform.localScale = new Vector2(-1, 1);
        }


    }
    private void OnTriggerEnter2D(Collider2D trig)
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
    void checkFireTime()
    {
        if(Time.time > nextFire)
        {
            Instantiate(Shot,transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    IEnumerator StartUfo()
    {
        anim.SetBool("Start",true);
        yield return new WaitForSeconds(2.1f);
        anim.SetBool("Patrol",true);
        Speed = 0.01f;
        InvokeRepeating("IncreaseSpeed",0,5f);
    }
    void IncreaseSpeed()
    {
        if(VerticalSpeed < 1)
        {
            VerticalSpeed += 0.2f;
        }
        

    }
}
