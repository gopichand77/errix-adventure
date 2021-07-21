using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 4f;
    Vector2 moveDirection;
    Player player;
    private Material matDefault;
    SpriteRenderer spriteRenderer;
    private UnityEngine.Object exploRef;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player  = GameObject.FindObjectOfType<Player>();
        moveDirection = (player.transform.position - transform.position).normalized *speed;
        rb.velocity = new Vector2(moveDirection.x,moveDirection.y) * speed;
        exploRef = Resources.Load("Explosion");
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
             Invoke("KillSelf", 0.05f);
            
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.4f);
       
    }
     
     public void KillSelf(){
      
        Destroy(gameObject);
         GameObject explosion = (GameObject)Instantiate(exploRef);
            explosion.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            
    }
}
