using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    Player player;
    public int damage;
    private float Timer;
    private float coolDown;
    public bool godMode = true;
       // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(Speed());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,2f);
        
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
         if(trig.gameObject.CompareTag("Player"))
        {
            godMode =  true;
            player.playerhurt.Damaged = true;
              rb.velocity = transform.right * 0;
              if(godMode)
              {
                  player.TakeDamage(damage);
                  player.playerhurt.Damaged = false;
                  godMode =  false;
              }
              
              
              
        }
    }

}
