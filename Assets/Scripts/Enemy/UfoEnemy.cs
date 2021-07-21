using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoEnemy : MonoBehaviour
{
    public float horizontalSpeed = 0;
    public float VerticalSpeed;
    public float amplitude;
    public float desiredPostionY;
    public bool movingRight;
    public Vector3 tempPosition;
    [SerializeField]
    Player player;
    float playerDist;
    public float rangeOfFire;
    float fireRate = 0.5f;
     float nextFire;
    [SerializeField]
    GameObject Shot;

    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDist = Vector2.Distance(transform.position, player.transform.position);

        if(playerDist < rangeOfFire)
        {
            checkFireTime();
        }
        

        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude + desiredPostionY;
        transform.position = tempPosition;
        if (movingRight)
        {
            horizontalSpeed = 0.01f;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {

            horizontalSpeed = -0.01f;
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
}
