using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthworm : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    public int health = 100;
    Rigidbody2D rb;

    // bool _hasDied;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
    }
    private void FixedUpdate()
    {
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }

        }

        if (trig.CompareTag("Bullet"))//collisons 
        {
            Destroy(trig.gameObject);
            health--;
            spriteRenderer.material = matWhite;
            if(health <= 0){
                KillSelf();
            }
        }
        //  if(trig.gameObject.tag == "Player")
        // {
        //     StartCoroutine(Die());

        // }

    }

    private void KillSelf(){
        Destroy(gameObject);
    }


}
