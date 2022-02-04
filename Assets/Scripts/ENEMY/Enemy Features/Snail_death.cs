using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail_death : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shockForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 2.5f;
        // rb.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * 100f * shockForce);
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject, 1.8f);
        
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
           
    }
    }
}
