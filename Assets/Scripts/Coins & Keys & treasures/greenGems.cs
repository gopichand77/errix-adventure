using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGems : MonoBehaviour
{
    public Animator anim;
    private bool gemCollected = true;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player") && gemCollected)
        {
            player.Collectables.NoOfgems();
            gemCollected = false;
            // Destroy(gameObject);
            anim.SetBool("collected", true);
            

            StartCoroutine(Collected());

        }
    }

    IEnumerator Collected()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
