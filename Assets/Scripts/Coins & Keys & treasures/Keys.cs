using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private bool KeyCollected = true;


    void OnTriggerEnter2D(Collider2D trig)
    {
        PlayerCollections player = trig.gameObject.GetComponent<PlayerCollections>();

        if (trig.gameObject.CompareTag("Player") && KeyCollected)
        {
            player.NoofKeys(1);
            StartCoroutine(Collected());
            KeyCollected  = false;
        }
    }

    IEnumerator Collected()
    {
        anim.SetBool("isCollected", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
