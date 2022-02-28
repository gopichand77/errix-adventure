using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTrigger : MonoBehaviour
{
    //========================================================//
    // This the script for Player Triggering events to Check Treasure Buttons and Attack Button //
    // This also checks for the keys and the bullets of the player//
   
    private  Player playerScript;
    // [Header("Attack Button")]
    internal Button AttackButton;
    // [Header("Treasure Keys Buttons")]
    internal Button TreasureKey1;
    internal Button TreasureKey2;
    internal Button TreasureKey3;
    internal Chest chest1;
    internal Chest chest2;
    internal Chest chest3;
    // Start is called before the first frame update
    void Start()
    {
        chest1 =  GameObject.Find("Chest1").GetComponent<Chest>();
        chest2 =  GameObject.Find("Chest2").GetComponent<Chest>();
        chest3 =  GameObject.Find("Chest3").GetComponent<Chest>();


        playerScript =  GetComponent<Player>();
        TreasureKey1 = GameObject.Find("Canvas/Controls Panel/Treasure Button 1").GetComponent<Button>();
        TreasureKey2 = GameObject.Find("Canvas/Controls Panel/Treasure Button 2").GetComponent<Button>();
        TreasureKey3 = GameObject.Find("Canvas/Controls Panel/Treasure Button 3").GetComponent<Button>();
        AttackButton =  GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();

        TreasureKey1.gameObject.SetActive(false);
        TreasureKey2.gameObject.SetActive(false);
        TreasureKey3.gameObject.SetActive(false);
        AttackButton.gameObject.SetActive(true);
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
            TreasureKey1.onClick.AddListener(chest1.OpenChest);
        }

        if (trig.gameObject.CompareTag("Treasure2"))
        {
            TreasureKey2.gameObject.SetActive(true);
            TreasureKey2.interactable = true;
            AttackButton.gameObject.SetActive(false);
            TreasureKey2.onClick.AddListener(chest2.OpenChest);

        }

        if (trig.gameObject.CompareTag("Treasure3"))
        {
            TreasureKey3.gameObject.SetActive(true);
            TreasureKey3.interactable = true;
            AttackButton.gameObject.SetActive(false);
            TreasureKey3.onClick.AddListener(chest3.OpenChest);

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
