using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
public class Player : MonoBehaviour
{
    //=============================================================================//
    //This Script is only Used for 
    //1. Player Damage Function
    //2. HealthBar
    //3. GaveOver Panel
    //4. Death of the Player.
    //5. Checkpoint
    [Header("Drag Player here")]
    [SerializeField]
    internal PlayerMovement MovementScript;
    [SerializeField]
    internal PlayerTrigger InteractButtons;
    [SerializeField]
    internal PlayerCollections Collectables;
    [SerializeField]
    internal PlayerHurt playerhurt;
    public GameObject damageTextPrefab;
    int textToDisplay;
    public GameObject GameOverPanel;
    public GameObject BlackScreen;
    public GameObject[] DeathOn;
    private Vector3 localScale;
    public float HurtForce = 30;
   [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public PlayerHealthSlider healthBar;
    private Vector3 checkPoint =  new Vector3(0,2,0);
    
    
    

 private void Start()
    {
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
               // audioSource = GetComponent<AudioSource>();
        GameOverPanel.SetActive(false);
        BlackScreen.SetActive(false);
        InteractButtons.AttackButton.interactable = false;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
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
            BlackScreen.SetActive(true);
             foreach (GameObject death in DeathOn)
            death.SetActive(true);
        }
        checkAttackButton();
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        Die();
        // if ()

    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("CheckPoint"))
        {
            checkPoint =  new Vector3(trig.transform.position.x,trig.transform.position.y+2,trig.transform.position.z);
        }
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
    public void TakeDamage( int damage)
    {
        // health -= damage;
        StartCoroutine(Hurt());
        if (playerhurt.Damaged || playerhurt.spikeDamaged || playerhurt.shotHurt)
        {
            currentHealth -= damage;
            // damage = textToDisplay;
            textToDisplay = damage;
             playerhurt.Damaged = false;
            playerhurt.spikeDamaged = false;
            playerhurt.shotHurt =  false;
            Invoke("Floating",0.5f);    
        }

        healthBar.SetHealth(currentHealth);
    }
    internal void Floating()
    {
        Vector3 PlayerPos =  new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
       GameObject DamageTextInstance = Instantiate(damageTextPrefab, PlayerPos, Quaternion.identity);
           DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-"+textToDisplay.ToString());
           Destroy(DamageTextInstance, 2f);
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
           
        //   gameObject.SetActive(false);
        spriteRenderer.enabled = false;
        rb.isKinematic = true;
        }
    }
    public void Revive()
    {
         rb.isKinematic = false;
          spriteRenderer.enabled = true;
      
        transform.position =  checkPoint;
    }
    IEnumerator GameTim()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
    }
    //count score
}