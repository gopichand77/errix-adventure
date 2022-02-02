using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_TriggerArea : MonoBehaviour
{   
            
    public WanderAttack parentScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trig)
    {   
         if(trig.gameObject.tag == "Player")
        {
            parentScript.target = trig.gameObject;
            parentScript.inRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            
            parentScript.inRange = false;
        }
    }
}
