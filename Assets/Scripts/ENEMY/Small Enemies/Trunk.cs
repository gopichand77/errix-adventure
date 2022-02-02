using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
     public Transform firepoint;
     public GameObject Pea;
     public PeaBullet peaBullet;
     public WanderAttack Parentpos;
  public void Shoot()
    {
        if(Parentpos.right)
        {
            peaBullet.speed = 10;
        }
        else
        {
            peaBullet.speed = -10;
        }
      Instantiate(Pea, firepoint.position, firepoint.rotation);
    //   Parentpos.TriggerCooling();
    }
    
}

