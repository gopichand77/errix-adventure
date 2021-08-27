using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    public Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        anim.SetBool("Throw", true);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Monster enemy = hitInfo.GetComponent<Monster>();

        // if (enemy != null)
        // {
        //     // enemy.TakeDamage(5);
        //     rb.velocity = transform.right * 0;
        //     anim.SetBool("isDestroy", true);
        //     StartCoroutine(Death());
        //     enemy.gameObject.SetActive(false);
        // }
        if (hitInfo.gameObject.CompareTag("Collider"))
        {
            rb.velocity = transform.right * 0;
            anim.SetBool("isDestroy", true);
            StartCoroutine(Death());
        }
        if(hitInfo.gameObject.name.Equals("Spider Boss"))
        {
            var spider = GameObject.FindObjectOfType<Boss_Spider>();
            rb.velocity = transform.right * 0;
            Destroy(gameObject);
            spider.TakeDamage(10);

        }
         if(hitInfo.gameObject.name.Equals("Tree enemy"))
        {
            var tree = GameObject.FindObjectOfType<Enemy_Behaviour>();
            rb.velocity = transform.right * 0;
            Destroy(gameObject);
            tree.TakeDamage();
            
        }

        //earthworm die
        // if (hitInfo.gameObject.CompareTag("Earthworm"))
        // {
        //     rb.velocity = transform.right * 0;
        //     anim.SetBool("isDestroy", true);
        //     StartCoroutine(Death());
        //     Destroy(hitInfo.gameObject);
        // }


    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Monster enemy = collision.gameObject.GetComponent<Monster>();


    //     if(collision.contacts[0].normal.y < -0.5 && collision.contacts[0].normal.x < -0.5)
    //     {
    //         Destroy(gameObject);

    //     }
    // }


}




