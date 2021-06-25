using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    
    public Sprite OpenChest;
    public SpriteRenderer spriteRenderer;
    public Collider2D treasure;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D trig)
    {
        Player player = trig.gameObject.GetComponent<Player>();

        if (trig.gameObject.CompareTag("Player"))
        {
            
            ChangeSprite();
            


            
        }
        
    }
    private void onTriggerExit2D(Collider2D trig)
    
        {
           Player player = trig.gameObject.GetComponent<Player>();
           

        if (trig.gameObject.CompareTag("Player"))
        {
            player.OpenTreasure();
            
            
            


            
        }

            
        }

    void ChangeSprite()
    {
        spriteRenderer.sprite = OpenChest;
    }
}
    // private void Update()
    // {
    //     Player player = gameObject.GetComponent<Player>();
    //     if(Input.GetKeyDown(KeyCode.) && player.Keys > 0)
    //     {
    //         ChangeSprite();

    //     }
        
    // }
    
// }
//OnTriggerEnter check for Keys  
//if keys> 0 then Enable Button
//Button OnClick Open Treasure and Reduce one Key

