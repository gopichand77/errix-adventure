using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
   internal Transform firepoint;
   public Transform Axeprefab;
   internal Animator anim;
   internal Button attack;
    
    // Update is called once per frame
    private void Start()
    {
        // AttackButton =  GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();
        attack = GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();
        attack.onClick.AddListener(Fire);
        firepoint =  transform.GetChild(1);
        anim = GetComponent<Animator>(); 
    }
    private void Update()
    {
        attack.onClick.AddListener(Fire);
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
        
    public void Shoot()
    {
        Instantiate(Axeprefab, firepoint.position,firepoint.rotation);
        

        StartCoroutine(ThrowAnime());
    }
    public IEnumerator ThrowAnime()
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
