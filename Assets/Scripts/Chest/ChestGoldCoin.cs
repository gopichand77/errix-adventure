using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGoldCoin : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private bool ChestOpened = true;
    internal PlayerCollections player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerCollections>();
        rb.velocity = transform.up *5 ;
        StartCoroutine(CoinOut());
        
    }

    IEnumerator Collected() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator CoinOut() {
        yield return new WaitForSeconds(0.5f);
      
        player.NoofGoldCoins();
        anim.SetBool("collectedCoin", true);
            StartCoroutine(Collected());
    }
}
