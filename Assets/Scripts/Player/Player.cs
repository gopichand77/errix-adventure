using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    //=============================================================================//
    //This Script is only Used for 
    //1.Player Damage Function
    //2.HealthBar
    //3.GaveOver Panel
    //4.Death of the Player.
     [SerializeField]
    internal PlayerMovement MovementScript;
    [SerializeField]
    internal PlayerTrigger InteractButtons;
    [SerializeField]
    internal PlayerCollections Collectables;
    [SerializeField]
    internal PlayerHurt playerhurt;

    public GameObject GameOverPanel;
    private Vector3 localScale;
    public float HurtForce = 30;
   [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealthSlider healthBar;
    

 private void Start()
    {
        GameOverPanel.SetActive(false);
        InteractButtons.AttackButton.interactable = false;
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
         //treasure reference 
        

       
        //for score
}
 private void Update()
    {
        if (currentHealth <= 0)
        {
            new WaitForSeconds(1);
            GameOverPanel.SetActive(true);
        }
        checkAttackButton();
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        Die();

    }
    public void checkAttackButton()
    {
        if (Collectables.Bullets > 0)
        {
            InteractButtons.AttackButton.interactable = true;
        }
        if (Collectables.Bullets == 0 || Collectables.Bullets < 0)
        {
            InteractButtons.AttackButton.interactable = false;
        }
    }
    public void TakeDamage(int damage)
    {
        // health -= damage;
        StartCoroutine(Hurt());
        if (playerhurt.Damaged || playerhurt.spikeDamaged)
        {
            currentHealth -= damage;
            playerhurt.Damaged = false;
            playerhurt.spikeDamaged = false;
        }
        healthBar.SetHealth(currentHealth);
    }
    IEnumerator Hurt()
    {   
        MovementScript.anim.SetBool("isFalling", false);
        MovementScript.anim.SetBool("isHurt", true);
        MovementScript.moveSpeed = 0;
        yield return new WaitForSeconds(0.8f);
        MovementScript.moveSpeed = 7;
        MovementScript.anim.SetBool("isHurt", false);


    }
    void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator GameTim()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
    }






   


   
    

    

   
   
    


    

 
   




   

    //count score



    



    



}


