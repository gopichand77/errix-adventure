using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform firepoint;
   public Transform Axeprefab;
   public Animator anim;
   public Button attack;
    
    // Update is called once per frame
    private void Start()
    {
        // attack = GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();
        // attack.onClick.AddListener(Fire);
        // firepoint =  GetComponentInChildren<>
        anim = GetComponent<Animator>(); 
    }
    private void Update()
    {
        // attack.onClick.AddListener(Shoot);
        if(Input.GetKeyDown(KeyCode.K))
        {
            Fire();
        }
        
        
        
    }
     public void Fire()
    {

        Shoot();
        
        PlayerCollections player = gameObject.GetComponent<PlayerCollections>();
        player.BulletHandler();
        
    }
        
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
