using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour{

	public float horizontalSpeed;
	public float VerticalSpeed;
	public bool onLand;
	public bool rushing = false;
	private float speedMod = 0;
	public GameObject GameOverPanel;
    public GameObject BlackScreen;
	public GameObject damageTextPrefab;
	[Header("Health")]
    internal int maxHealth = 200;
    internal int currentHealth = 200;
    internal float dirX;
	int textToDisplay;
    internal float dirY;
	float timeLeft = 2f;
	internal FiremanHurt playerhurt;
	internal Rigidbody2D rb;
	internal PlayerHealthSlider healthBar;
	private Animator myAnim;

	public GameObject bubbles;

	// Use this for initialization
	void Start (){
		healthBar =  FindObjectOfType<PlayerHealthSlider>();
		playerhurt =  GetComponent<FiremanHurt>();
		rb = GetComponent<Rigidbody2D> ();	
		myAnim = GetComponent<Animator> ();
		healthBar.SetMaxhealth(maxHealth);
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate (){
	#if UNITY_EDITOR
    dirX = Input.GetAxis("Horizontal") * horizontalSpeed;
    dirY = Input.GetAxis("Vertical") * VerticalSpeed;
	#endif
	rb.velocity = new Vector2(dirX, rb.velocity.y);
	rb.velocity = new Vector2(rb.velocity.x,dirY);
	if (Input.GetAxisRaw ("Horizontal") > 0f) {
			transform.localScale = new Vector3(1f,1f,1f);
			
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {			
			transform.localScale = new Vector3(-1f,1f,1f);
			
		}
    

		// resetBoostTime ();
		// controllerManager ();



		if(!onLand)
		{
			myAnim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));
		myAnim.SetFloat ("Vertical", Mathf.Abs(rb.velocity.y));
		myAnim.SetBool("isRunning", false);
		}
		else if(onLand)
		{
			myAnim.SetBool("isRunning", true);
			myAnim.SetFloat("Vertical",0);
			myAnim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));

		}
		else
		{
			
		}
		 if (currentHealth == 0 || currentHealth < 0)
        {
            new WaitForSeconds(1);
            GameOverPanel.SetActive(true);
            BlackScreen.SetActive(true);
            //  foreach (GameObject death in DeathOn)
            // death.SetActive(true);
            gameObject.SetActive(false);
        }

	 
		
	}

	void controllerManager (){
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			transform.localScale = new Vector3(1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {			
			transform.localScale = new Vector3(-1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Vertical") > 0f) {
			rb.velocity = new Vector3 (rb.velocity.x, horizontalSpeed, 0f);
		} else if (Input.GetAxis ("Vertical") < 0f) {
			rb.velocity = new Vector3 (rb.velocity.x, -horizontalSpeed, 0f);
		}
		// if(Input.GetAxisRaw ("Horizontal") > 0f && Input.GetAxisRaw ("Vertical") > 0f)
		// {
		// 	transform.localScale = new Vector3(1f,1f,1f);
		// 	rb.velocity = new Vector3 (rb.velocity.x, horizontalSpeed, 0f);
		// 	movePlayer ();
		// }
		// if(Input.GetAxisRaw ("Horizontal") > 0f && Input.GetAxis ("Vertical") < 0f)
		// {
		// 	transform.localScale = new Vector3(1f,1f,1f);
		// 	rb.velocity = new Vector3 (rb.velocity.x, -horizontalSpeed, 0f);
		// 	movePlayer ();

		// }
		// if(Input.GetAxisRaw ("Horizontal") < 0f && Input.GetAxisRaw ("Vertical") > 0f)
		// {
		// 	rb.velocity = new Vector3 (rb.velocity.x, horizontalSpeed, 0f);
		// 	transform.localScale = new Vector3(-1f,1f,1f);
		// 	movePlayer ();

		// }
		// if(Input.GetAxisRaw ("Horizontal") < 0f && Input.GetAxis ("Vertical") < 0f)
		// {
		// 	rb.velocity = new Vector3 (rb.velocity.x, -horizontalSpeed, 0f);
		// 	transform.localScale = new Vector3(-1f,1f,1f);
		// 	movePlayer ();

		// }

		if(Input.GetButtonDown("Jump")){
			// rushing = true;
			speedMod = 2;
			Instantiate (bubbles, gameObject.transform.position, gameObject.transform.rotation);
			movePlayer ();
		}	
	}

	void movePlayer(){
		if (transform.localScale.x == 1) {
			rb.velocity = new Vector3 (horizontalSpeed + speedMod, rb.velocity.y, 0f);	
		} else {
			rb.velocity = new Vector3 (- (horizontalSpeed + speedMod), rb.velocity.y, 0f);
		}	
	}

	// void resetBoostTime(){
	// 	if (timeLeft <= 0) {
	// 		timeLeft = 2f;
	// 		rushing = false;
	// 		speedMod = 0;
	// 	} else if(rushing) {
	// 		timeLeft -= Time.deltaTime;
	// 	}	
	// }

	public void hurt(){
		

	}
	private void OnTriggerEnter2D(Collider2D trig)
	{
		if(trig.gameObject.CompareTag("Collider"))
		{
			onLand = true;
			myAnim.SetBool("idle",true);
		}
		
		
	}
	private void OnTriggerExit2D(Collider2D trig)
	{
		if(trig.gameObject.CompareTag("Collider"))
		{
			onLand = false;
			myAnim.SetBool("idle",false);
		}	
	}
	 public void TakeDamage(int damage)
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
            playerhurt.shotHurt = false;
            Invoke("Floating", 0.5f);
        }

        healthBar.SetHealth(currentHealth);
    }
	IEnumerator Hurt()
    {
       
        horizontalSpeed = 0;
		VerticalSpeed = 0;

        yield return new WaitForSeconds(0.8f);
       horizontalSpeed = 8;
		VerticalSpeed = 8;


    }
	internal void Floating()
    {
        Vector3 PlayerPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, PlayerPos, Quaternion.identity);
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-" + textToDisplay.ToString());
        Destroy(DamageTextInstance, 2f);
    }
    
}

