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
  
        
        // Dialog.gameObject.SetActive(false);
        
    
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
            SignBoardActive(collision);
        }

        bool SignBoardActive(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
           if(collision.contacts[0].normal.y < -0.5){
                Dialog.gameObject.SetActive(true);//Dialg Box is Deactivated To Activate Keep True
               
             return true;
           }
           return false;
}
}
