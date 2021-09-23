using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
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

    void FixedUpdate()
    {
         if (moving)
        {
            transform.position += (velocity * Time.fixedDeltaTime);
        }
        XDir();
        YDir();
        // if(transform.position.x  > rightLimit && transform.position.y > topLimit)
        // {
        //     movingSide  =  false;
        // }
        // if(transform.position.x  < leftLimit && transform.position.y < bottomLimit)
        // {
        //     movingSide = true;
        // }
        // if(movingSide)
        // {
        //     transform.position =  new Vector2(transform.position.x + moveSpeed * Time.deltaTime,transform.position.y + moveSpeed * Time.deltaTime);
        // }
        // if(!movingSide)
        // {
        //     transform.position =  new Vector2(transform.position.x - moveSpeed * Time.deltaTime,transform.position.y - moveSpeed * Time.deltaTime);
        // }



        
        

        
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
            if(yDir)
        {
             if (transform.position.y - gridPos > topLimit)
        {
            moveTop = false;
        }
        if (transform.position.y - gridPos < -bottomLimit)
        {
            moveTop = true;
        }

        if (moveTop)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = new Vector2(transform.position.x,transform.position.y - moveSpeed * Time.deltaTime);
        }
        }
        
    }
    


    

    private void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();
        if (player)
        {
            moving = true;
            trig.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        trig.gameObject.transform.SetParent(null);
    }

    
}