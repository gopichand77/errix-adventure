using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    
    
    internal PlayerMovement MovementScript;
    internal PlayerTrigger InteractButtons;
    internal PlayerCollections Collectables;
    internal PlayerHurt playerhurt;
    public GameObject damageTextPrefab;
    int textToDisplay;
    public GameObject GameOverPanel;
    public GameObject[] GameOverChilds;
    public GameObject BlackScreen;
    // public GameObject[] DeathOn;
    private Vector3 localScale;
    // public float HurtForce = 30;
   [Header("Health")]
    internal int maxHealth = 200;
    internal int currentHealth = 200;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    internal PlayerHealthSlider healthBar;
    private Vector3 checkPoint =  new Vector3(0,2,0);
    
    
    

 private void Start()
    {
        getPlayer();
        currentHealth = 200;
        maxHealth = 200;

        // GameOverPanel =  GameObject.Find("Game Over Panel");
        // GameOverChilds =  GameOverPanel.GetComponentInChildren<ImagePanel>()
        checkPoint =  new Vector3(0,2,0);
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

        if (currentHealth == 0 || currentHealth < 0)
        {
            new WaitForSeconds(1);
            GameOverPanel.SetActive(true);
            BlackScreen.SetActive(true);
            //  foreach (GameObject death in DeathOn)
            // death.SetActive(true);
           gameObject.SetActive(false);
        }
        checkAttackButton();
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        
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
           
          gameObject.SetActive(true);
        spriteRenderer.enabled = false;
        rb.isKinematic = true;
        }
    }
    public void Revive()
    {
        currentHealth = 200;
         rb.isKinematic = false;
          spriteRenderer.enabled = true;
       gameObject.SetActive(true);
        transform.position =  checkPoint;
        GameOverPanel.SetActive(false);
        BlackScreen.SetActive(false);
    }
    IEnumerator GameTim()
    {
        yield return new WaitForSeconds(2);
        GameOverPanel.SetActive(true);
    }
    void getPlayer()
    {
                MovementScript =GetComponent<PlayerMovement>();
        InteractButtons = GetComponent<PlayerTrigger>();
        Collectables = GetComponent<PlayerCollections>();
        playerhurt = GetComponent<PlayerHurt>();
        healthBar = GameObject.FindObjectOfType<PlayerHealthSlider>();
    }
    //count score
}