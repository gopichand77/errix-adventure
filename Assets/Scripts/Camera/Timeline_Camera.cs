using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline_Camera : MonoBehaviour
{
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(npc.GetComponentInChildren<Renderer>().isVisible)
    //     {
    //         Debug.Log("Yes I am Here");

    //     }
    //     else 
    //     {
    //         Debug.Log("You Cant' See me");
             
    //     }
        
    // }
    private void OnBecameVisible()
    {
        Debug.Log("I am Here");
        
        
    }
    private void OnBecameInvisible()
    {
        Debug.Log("You con't see me");
    }
}
