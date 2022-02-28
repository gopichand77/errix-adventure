using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
   internal Transform firepoint;
   public Transform Axeprefab;
   internal Animator anim;
   internal Button attack;
    PlayerCollections player;
    public bool fire;
    // Update is called once per frame
    private void Start()
    {
        fire = CrossPlatformInputManager.GetButtonDown("Fire1");
        player = gameObject.GetComponent<PlayerCollections>();
        // AttackButton =  GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();
        attack = GameObject.Find("Canvas/Controls Panel/Attack").GetComponent<Button>();
        attack.onClick.AddListener(Fire);
        firepoint =  transform.GetChild(1);
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
            
        
        
        
        player.BulletHandler();
        
    }
        
    public void Shoot()
    {
        StartCoroutine(ThrowAnime());    
    }
    public IEnumerator ThrowAnime()
        {
            Instantiate(Axeprefab, firepoint.position,firepoint.rotation); 
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
