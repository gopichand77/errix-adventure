using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(Speed());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = transform.right *speed;
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Collider"))
        {
              rb.velocity = transform.right * 0;
              anim.SetBool("isDestroyed", true);
              Destroy(gameObject,0.5f);
        }
    }

}
