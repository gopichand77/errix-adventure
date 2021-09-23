using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStand : MonoBehaviour
{
    public Collider2D BoxCollider;
    public float coolDownOn;
    public float coolDownOff;
    private Animator anim;
    public int spikeDamge = 10;
    private bool onFire;
    // Start is called before the first frame update
    void Start()
    {
        
        anim =  GetComponent<Animator>();  
        StartCoroutine(CoolDown());      
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(onFire)
        {
            if (collider2D.gameObject.tag == "Player")
        {
            var player = collider2D.GetComponent<Player>();
            if (player.playerhurt.spikeDamaged)
            {
                player.TakeDamage(spikeDamge);
                player.playerhurt.spikeDamaged = false;
                player.MovementScript.anim.SetBool("isHurt",true);
                player.MovementScript.anim.SetBool("isFalling",false);
                player.MovementScript.moveSpeed = 7;
                
            }
            player.playerhurt.spikeKnockCount = player.playerhurt.knockLenght;
            player.playerhurt.spikeHurt = true;
        }
        }
    }
    IEnumerator CoolDown()

    {
        yield return new WaitForSeconds(coolDownOn);
        BoxCollider.enabled = false;
        onFire = false;
        anim.SetBool("CoolDown",true);
        Invoke("Off",coolDownOff);
       


    }
    void Off()
    {
        
        BoxCollider.enabled =  true;
       
        onFire = true;
        anim.SetBool("CoolDown", false);
        StartCoroutine(CoolDown());
    }
}
