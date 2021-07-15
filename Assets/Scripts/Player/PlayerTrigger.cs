using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTrigger : MonoBehaviour
{
    //========================================================//
    // This the script for Player Triggering events to Check Treasure Buttons and Attack Button //
    // This also checks for the keys and the bullets of the player//
    [SerializeField]
    Player playerScript;
     [Header("AttackButtons")]
    public Button AttackButton;
    public Button TreasureKey1;
    public Button TreasureKey2;
    public Button TreasureKey3;
    // Start is called before the first frame update
    void Start()
    {
        TreasureKey1.gameObject.SetActive(false);
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("greenGem"))
        {
            Destroy(trig.gameObject);

            playerScript.Collectables.NoOfgems();
        }
        if (trig.gameObject.CompareTag("Treasure"))
        {
            TreasureKey1.gameObject.SetActive(true);
            AttackButton.gameObject.SetActive(false);
            TreasureKey1.interactable = true;
        }

        if (trig.gameObject.CompareTag("Treasure2"))
        {
            TreasureKey2.gameObject.SetActive(true);
            TreasureKey2.interactable = true;
            AttackButton.gameObject.SetActive(false);

        }

        if (trig.gameObject.CompareTag("Treasure3"))
        {
            TreasureKey3.gameObject.SetActive(true);
            TreasureKey3.interactable = true;
            AttackButton.gameObject.SetActive(false);

        }
        if (playerScript.Collectables.Keys == 0)
        {
            TreasureKey2.interactable = false;
            TreasureKey3.interactable = false;
            TreasureKey1.interactable = false;
        }


    }
     private void OnTriggerExit2D(Collider2D other)
    {
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);
        TreasureKey1.gameObject.SetActive(false);
        AttackButton.gameObject.SetActive(true);
    }
}
