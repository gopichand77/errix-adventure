using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigggerArea : MonoBehaviour
{
    private Enemy_Behaviour enemyParent;

    private void Awake()
    {
        enemyParent =  GetComponentInParent<Enemy_Behaviour>();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = trig.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
