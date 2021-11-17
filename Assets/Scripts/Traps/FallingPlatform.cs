using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Vector2 Position;
    SpriteRenderer rend;
    // public SpriteRenderer rendChild;
    // public BoxCollider2D box2;
    Quaternion thisRot;
    BoxCollider2D box;
   
    Rigidbody2D rb;
    Color shift;
    Animator anim;
    public float standTime = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
       
        rend = GetComponent<SpriteRenderer>();
        thisRot = Quaternion.identity;
        thisRot.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        // rotation = new 
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic =  true;
        box = gameObject.GetComponent<BoxCollider2D>();
        Position = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("Position:" + Position);
    }
    private void Update()
    {
        //   if(rendChild == null)
        // {
        //     Debug.Log("This Object is null");
        // }
        // else
        // {
        //     Debug.Log("This Object there");
            
        // }
    }

    // Update is called once per frame
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Collider"))
        {
            
            rend.color = new Color(1f, 1f, 1f, 0f);
            // rendChild.color = new Color(1f, 1f, 1f, 0f);
        }


    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(Fall());

            // gameObject.SetActive(false);

        }



    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(standTime);
        rb.isKinematic = false;
        
        anim.Play("Yellow idle");
        StartCoroutine(Downcolor());
        
        yield return new WaitForSeconds(0.1f);
        Invoke("Respawan", 1.9f);
        box.enabled = false;
        // box2.enabled = false;
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
        StopCoroutine(Downcolor());
        anim.Play("Yellow Rotating");
        yield return new WaitForSeconds(0.3f);
       rend.color = new Color(1f, 1f, 1f, 0.4f);
    //    rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        //  rendChild.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        // rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        // rendChild.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        // rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        // rendChild.color = new Color(1f, 1f, 1f, 1f);
        box.enabled = true;
        // box2.enabled = true;
        }
     IEnumerator Downcolor()
    {
        
        yield return new WaitForSeconds(0.3f);
       rend.color = new Color(1f, 1f, 1f, 0.4f);
    //    rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        // rendChild.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        //  rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        // rendChild.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 0.4f);
        // rendChild.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        // rendChild.color = new Color(1f, 1f, 1f, 1f);
        

    }


}
