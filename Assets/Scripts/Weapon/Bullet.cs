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
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        anim.SetBool("Throw", true);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Monster enemy = hitInfo.GetComponent<Monster>();

        if(hitInfo.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
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
       

    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
    


}




