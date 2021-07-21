using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    Vector2 moveDirection;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player  = GameObject.FindObjectOfType<Player>();
        moveDirection = (player.transform.position - transform.position).normalized *speed;
        rb.velocity = new Vector2(moveDirection.x,moveDirection.y);
        Destroy(gameObject,10f);

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Monster enemy = hitInfo.GetComponent<Monster>();
          
        if (hitInfo.gameObject.CompareTag("Collider"))
        {
            rb.velocity = transform.right * 0;
             Destroy(gameObject);
            
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.4f);
       
    }
}
