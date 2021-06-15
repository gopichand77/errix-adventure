using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform firepoint;
   public Transform Axeprefab;
   public Animator anim;

    // Update is called once per frame
    void Update()
    {
    //    if(Input.GetButtonDown("Fire1"))
    //     {
    //        Shoot();
    //     }  
   // Fire();
    }
     public void Fire()
    {
        Shoot();
        
    void Shoot()
    {
        Instantiate(Axeprefab, firepoint.position,firepoint.rotation);
        StartCoroutine(ThrowAnime());
       }
    IEnumerator ThrowAnime()
        {
            anim.SetBool("throw",true);
            yield return new WaitForSeconds(0.2f);
            anim.SetBool("throw",false);


        }
        

    //  IEnumerator Die()
    //     {
    //         _hasDied = true;
    //         MovementSpeed = 0;
    //        animator.SetBool("collided", true);
    //         yield return new WaitForSeconds(0.2f);
    //          gameObject.SetActive(false);
    //     }
    
    }
    
}
