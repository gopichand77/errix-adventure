using UnityEngine;

public class Spider_trigger_Area : MonoBehaviour
{
    private  Boss_Spider enemyParent;

    private void Awake()
    {
        enemyParent =  GetComponentInParent<Boss_Spider>();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player") )
        {
            gameObject.SetActive(false);
            enemyParent.target = trig.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
