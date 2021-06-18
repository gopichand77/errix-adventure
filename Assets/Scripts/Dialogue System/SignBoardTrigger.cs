using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBoardTrigger : MonoBehaviour
{
    public GameObject Dialog;
    private bool PlayerRange;
    
    // Start is called before the first frame update
    void Start()
    {
        Dialog.gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
    
        if(PlayerRange)
        {
            Dialog.gameObject.SetActive(true);
        }
        
        // Dialog.gameObject.SetActive(false);
        
    }
    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     if(hitInfo.CompareTag("Player"))
    //     {
    //     PlayerRange = true;
    //     Debug.Log("Player is true");
    //     }
    // }
  void OnCollisionEnter2D(Collision2D collision)
        {
            ShouldDieFromCollision(collision);
            
        }

        bool ShouldDieFromCollision(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
           if(collision.contacts[0].normal.y < -0.5){
                Dialog.gameObject.SetActive(true);
               
             return true;
           }
           return false;
}
}
