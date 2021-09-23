using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalPlatform : MonoBehaviour
{
    [Header("XLimits")]
    public float rightLimit;
    public float leftLimit;
    [Header("yLimits")]
    public float topLimit;
    public float bottomLimit;
    // public bool Diagnol;
    public float moveSpeed = 3f;
    public bool movingSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(transform.position.x  > rightLimit && transform.position.y > topLimit)
        {
            movingSide  =  false;
        }
        if(transform.position.x  < leftLimit && transform.position.y < bottomLimit)
        {
            movingSide = true;
        }
        if(movingSide)
        {
            transform.position =  new Vector2(transform.position.x + moveSpeed * Time.deltaTime,transform.position.y + moveSpeed * Time.deltaTime);
        }
        if(!movingSide)
        {
            transform.position =  new Vector2(transform.position.x - moveSpeed * Time.deltaTime,transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
