using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Speed());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = transform.right *speed;
    }

}
