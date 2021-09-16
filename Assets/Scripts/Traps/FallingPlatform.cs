using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Vector2 Position;
    SpriteRenderer rend;
    Quaternion thisRot;
    BoxCollider2D box;
    Rigidbody2D rb;
    Color shift;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        thisRot = Quaternion.identity;
        thisRot.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        // rotation = new 
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();
        Position = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("Position:" + Position);


    }

    // Update is called once per frame
    void Update()
    {
        // rend.a = 0.4f;



    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Collider"))
        {
            box.enabled = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 2f);

            // gameObject.SetActive(false);

        }



    }
    void Fall()
    {
        rb.isKinematic = false;
        anim.Play("Yellow idle");
        Invoke("Respawan", 1.9f);

    }
    void Respawan()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.rotation = thisRot;
        transform.position = Position;
        StartCoroutine(Changecolor());
        


    }
    IEnumerator Changecolor()
    {
        anim.Play("Yellow Rotating");
        yield return new WaitForSeconds(0.3f);
       rend.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        box.enabled = true;

    }


}
