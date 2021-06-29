using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player"))
        {
            player.NoofCoins();
            // Destroy(gameObject);
            anim.SetBool("collectedCoin", true);
            StartCoroutine(Collected());
            
        }
    }

    IEnumerator Collected() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}






