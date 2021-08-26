using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_HotZone : MonoBehaviour
{
    private Boss_Spider enemyParent;
   private bool inRange;
   private Animator anim;

   private void Awake()
   {
     enemyParent = GetComponentInParent<Boss_Spider>();
     anim = GetComponentInParent<Animator>();
   }
   private void Update()
   {
       if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Spider_attack"))
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
