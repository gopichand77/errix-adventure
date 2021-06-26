using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public Animator anim;
    // private bool oneClick;
    // Start is called before the first frame update
    
    private void Start()
        {
            // oneClick = true;
            
        }
      public void OpenTreasure()
    {
        
        Player player = gameObject.GetComponent<Player>();
        Treasure treasure = gameObject.GetComponent<Treasure>();
        
        
        Debug.Log("TreasureOpened");
        anim.SetBool("Open",true);
      //  player.OpenTreasure();
        // oneClick = false;

        
       
    }

}
