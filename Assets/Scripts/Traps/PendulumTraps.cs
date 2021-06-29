using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumTraps : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }

    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1*moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
         Player player = collison.gameObject.GetComponent<Player>();
        if(player.currentHealth > 30)
        {
            player.TakeDamage(30);
        }
        if(player.currentHealth == 10)
        {
            player.TakeDamage(10);
        }
        if( player.currentHealth == 20)
        {
            player.TakeDamage(20);

        }
        if(player.currentHealth < 1)
        {
            Destroy(player.gameObject);

        }
        
 
    }
}