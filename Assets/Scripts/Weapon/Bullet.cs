using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool Death;

    public Animator Axe;




    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Monster enemy = hitInfo.GetComponent<Monster>();
        if (enemy != null)
        {
            // enemy.TakeDamage(5);
            enemy.gameObject.SetActive(false);

        }
        Destroy(gameObject);



    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            Destroy(this.gameObject);
        }
    }


}
