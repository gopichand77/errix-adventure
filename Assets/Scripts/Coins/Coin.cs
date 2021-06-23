using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
  
     void OnTriggerEnter2D(Collider2D trig)
    {
         Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player"))
        {
           player.NoofCoins();
Destroy(gameObject);
        }
    }
}






