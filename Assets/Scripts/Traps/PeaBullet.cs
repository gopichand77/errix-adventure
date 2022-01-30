using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
     public float speed = 10f;
    public Rigidbody2D rb;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            // anim.SetBool("Destroy",true);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
