using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGems : MonoBehaviour
{
    Player player;
    public Rigidbody2D rb;
    public Animator anim;
    // private bool ChestOpened;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        rb.velocity = transform.up *5 ;
        player.Collectables.NoOfgems();
        StartCoroutine(CoinOut());
        // ChestOpened = false;
        
    }

    // Update is called once per frame
    // void OnTriggerEnter2D(Collider2D trig)
    // {
    //     Player player = trig.gameObject.GetComponent<Player>();

    //     if (trig.gameObject.CompareTag("Player") && ChestOpened)
    //     {
            
            
            
            
            
    //     }
    // }

    IEnumerator Collected() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator CoinOut() {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("collected", true);
            StartCoroutine(Collected());
    }
}
