using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }
  
    void destroyThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        StartCoroutine(Destroying());
        
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Break",true);
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic =  false;
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Falling",true);
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        


    }
}
