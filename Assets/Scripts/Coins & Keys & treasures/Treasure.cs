using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    
    public Sprite OpenChest;
    public SpriteRenderer spriteRenderer;
    
   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.V))
       {
           ChangeSprite();
                  }
   }
    
   
    public void OpenTreasure()
    {
        
       spriteRenderer.sprite = OpenChest;
    }

    void ChangeSprite()
    {
        
    }
}
   

//OnTriggerEnter check for Keys   Done
//if keys> 0 then Enable Button Done
//Button OnClick Open Treasure and Reduce one Key

