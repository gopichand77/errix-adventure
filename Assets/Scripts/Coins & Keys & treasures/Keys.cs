using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;


    void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player"))
        {
            player.NoofKeys();
            StartCoroutine(Collected());
        }
    }

    IEnumerator Collected()
    {
        anim.SetBool("isCollected", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
