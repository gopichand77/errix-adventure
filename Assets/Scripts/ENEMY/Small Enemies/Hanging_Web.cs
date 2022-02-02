using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging_Web : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    Player player;
    public int damage;
    public bool isHurt;
    public bool Hanging = true;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        if(Hanging)
        {
            dir =  -transform.up;

        }
        else if(!Hanging)
        {
            dir = transform.right;
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(Speed());
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }


    IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Collider"))
        {
            rb.velocity = transform.right * 0;
            anim.SetBool("isDestroyed", true);
            Destroy(gameObject, 0.5f);
        }
        if (trig.gameObject.CompareTag("Player") && !isHurt)
        {
            isHurt = true;

            rb.velocity = transform.right * 0;
            rb.isKinematic = true;

            StartCoroutine(Damage());
        }
    }


    private void CanHurt()
    {
        isHurt = false;
    }

    IEnumerator Damage()
    {
        if (isHurt)
        {
            // player.MovementScript.ctrlActive = false;
            StartCoroutine(Destroy());
            player.playerhurt.Damaged = true;
            player.TakeDamage(10);
        }

        yield return new WaitForSeconds(3f);
        isHurt = false;
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        player.MovementScript.ctrlActive = true;
        player.MovementScript.moveSpeed = 7f;
    }
}