using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private bool AxeCollected = true;
    public int NoOfBullets = 5;

    void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player") && AxeCollected)
        {
            anim.SetBool("isCollected", true);
            player.Collectables.Bullets = player.Collectables.Bullets + NoOfBullets;
            StartCoroutine(Collected());
            AxeCollected = false;



            // Destroy(gameObject);

        }
    }

    IEnumerator Collected()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);


    }
}
