using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    private bool CoinCollected = true;
    public AudioSource audioSource;
 private void Update()
 {
    audioSource = GetComponent<AudioSource>();
 }
    void OnTriggerEnter2D(Collider2D trig)
    {
        PlayerCollections player = trig.gameObject.GetComponent<PlayerCollections>();

        if (trig.gameObject.CompareTag("Player") && CoinCollected)
        {
            
            player.NoofGoldCoins();
            CoinCollected = false;
            // Destroy(gameObject);
            anim.SetBool("collectedCoin", true);
            

            StartCoroutine(Collected());

        }
    }

    IEnumerator Collected()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        
    }
}






