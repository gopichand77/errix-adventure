using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public bool Death;

    public Animator Axe;




    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update(){
        StartCoroutine(BulletDie());
    }
    IEnumerator BulletDie() {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     // Monster enemy = hitInfo.GetComponent<Monster>();
    //     // if(enemy !=null)
    //     // {
    //     //     enemy.TakeDamage(5);

    //     //     }




    // }

    // Update is called once per frame

}
