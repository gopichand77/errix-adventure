using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Boss_Hurt : MonoBehaviour
{
    public int Helath = 100;
    public BossHealth bossHealth;
    public int maxHealth = 100;
    public GameObject damageTextPrefab;
    int textToDisplay;
    public bool Dead = false;
    public List<GameObject> fightCol;
    // Start is called before the first frame update
    private void Awake()
    {
       
         bossHealth.SetMaxhealth(maxHealth);
    }
    private void Start()
    {
         foreach (GameObject Coll in fightCol)
            {
                Coll.SetActive(false);
            }
    }
  
    private void OnTriggerEnter2D(Collider2D trig)
    {
          if(trig.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
         
            
        }
    }
     public void TakeDamage(int damage) // The health is reduced in the bullet Script
    {
        if(Helath > 0)
        {
             Helath -= damage;
             textToDisplay = damage;
         bossHealth.SetHealth(Helath);
        }
        else if(Helath <= 0)
        {
            Debug.Log("Boss Dead");
            Dead =  true;
            Destroy(this.gameObject);
            foreach (GameObject Coll in fightCol)
            {
                Coll.SetActive(false);
            }
            // anim.SetBool("Dead",true);
        }
        //  StartCoroutine(Damage());


    }
    internal void Floating()
    {
        Vector3 PlayerPos =  new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
       GameObject DamageTextInstance = Instantiate(damageTextPrefab, PlayerPos, Quaternion.identity);
           DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-"+textToDisplay.ToString());
           Destroy(DamageTextInstance, 2f);
    }
}
