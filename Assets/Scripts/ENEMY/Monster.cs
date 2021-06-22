using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator animator;
    public int health = 40;
    Rigidbody2D rb;
    public SpriteRenderer DeathAffect;


    bool _hasDied;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * moveSpeed, 0, 0);
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


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }

    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (_hasDied)
            return false;

        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }


        return false;
    }
    IEnumerator Die()
    {
        _hasDied = true;
        moveSpeed = 0;
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }

    }

}


