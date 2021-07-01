using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D trig)
    {
        
        
        if(trig.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Done",true);


        }
    }
}
