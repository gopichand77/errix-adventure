using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    // Start is called before the first frame update
   private Enemy_Behaviour enemyParent;
   private bool inRange;
   private Animator anim;

   private void Awake()
   {
     enemyParent = GetComponentInParent<Enemy_Behaviour>();
     anim = GetComponentInParent<Animator>();
   }
   private void Update()
   {
       if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
       {
           enemyParent.Flip();
       }
   }
   private void OnTriggerEnter2D(Collider2D trig)
   {
       if(trig.gameObject.CompareTag("Player"))
       {
           inRange =  true;
       }
   }
   private void OnTriggerExit2D(Collider2D trig)
   {
       if(trig.gameObject.CompareTag("Player"))
       {
           inRange =  false;
           gameObject.SetActive(false);
           enemyParent.triggerArea.SetActive(true);
           enemyParent.inRange =  false;
           enemyParent.SelectTarget();
       }
   }
}
