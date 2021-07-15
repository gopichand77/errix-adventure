using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGoldCoin : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private bool ChestOpened = true;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up *5 ;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player") && ChestOpened)
        {
            
            player.Collectables.NoofGoldCoins();
            ChestOpened = false;
            StartCoroutine(CoinOut());
            
            
        }
    }

    IEnumerator Collected() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator CoinOut() {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("collectedCoin", true);
            StartCoroutine(Collected());
    }
}
