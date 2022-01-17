using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpike : MonoBehaviour
{
    public float moveSpeed = 3f;
    bool moveRight = true;
    bool moveTop = true;
    public float gridPos;
    [SerializeField] private Vector3 velocity;
    private bool moving;
    public bool yDir  = false;
    [Header("XLimits")]
    public float rightLimit;
    public float leftLimit;
    [Header("yLimits")]
    public float topLimit;
    public float bottomLimit;
    public bool Diagnol;
    public bool movingSide;
    public int EnemyDamage;
   
    void FixedUpdate()
    {
       
         if (moving)
        {
            transform.position += (velocity * Time.fixedDeltaTime);
        }
        XDir();
        YDir();
    }
    void XDir()
    {
        if(!yDir)
        {
            if (transform.position.x - gridPos > rightLimit)
        {
            moveRight = false;
        }
        if (transform.position.x - gridPos < -leftLimit)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        }
    }
    void YDir()
    {
        //     if(yDir)
        // {
        //      if (transform.position.y - gridPos > topLimit)
        // {
        //     moveTop = false;
        // }
        // if (transform.position.y - gridPos < -bottomLimit)
        // {
        //     moveTop = true;
        // }

        if (moveTop)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = new Vector2(transform.position.x,transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
        
    
    


    private void OnTriggerEnter2D(Collider2D col)
    {
        //  if (col.gameObject.CompareTag("Player"))
        //          {

        //     var player = col.gameObject.GetComponent<Player>();
        //     if (player.playerhurt.Damaged)
        //     {
        //         player.TakeDamage(EnemyDamage);
        //         player.MovementScript.anim.SetBool("isHurt", true);
        //         player.playerhurt.Damaged = false;
        //     }
        //     player.playerhurt.knockCount = player.playerhurt.knockLenght;

        //     if (col.transform.position.x < transform.position.x)
        //     {
        //         player.playerhurt.knockfromRight = true;
        //     }
        //     else
        //     {
        //         player.playerhurt.knockfromRight = false;
        //     }

        // }
        if(col.gameObject.CompareTag("Collider") )
        {
            if(moveTop)
            {
                moveTop=false;
            }
            else
            {
                moveTop = true;
            }
        }
    }

   

   

}
