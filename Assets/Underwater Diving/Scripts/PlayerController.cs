using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public float horizontalSpeed;
	public float VerticalSpeed;
	public bool onLand;
	public bool rushing = false;
	private float speedMod = 0;

    internal float dirX;
    internal float dirY;
	float timeLeft = 2f;

	private Rigidbody2D myRigidBody;
	
	private Animator myAnim;

	public GameObject bubbles;

	// Use this for initialization
	void Start (){
		myRigidBody = GetComponent<Rigidbody2D> ();	
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate (){
	#if UNITY_EDITOR
    dirX = Input.GetAxis("Horizontal") * horizontalSpeed;
    dirY = Input.GetAxis("Vertical") * VerticalSpeed;
	#endif
	myRigidBody.velocity = new Vector2(dirX, myRigidBody.velocity.y);
	myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,dirY);
	if (Input.GetAxisRaw ("Horizontal") > 0f) {
			transform.localScale = new Vector3(1f,1f,1f);
			
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {			
			transform.localScale = new Vector3(-1f,1f,1f);
			
		}
    

		resetBoostTime ();
		// controllerManager ();



		if(!onLand)
		{
			myAnim.SetFloat ("Speed", Mathf.Abs(myRigidBody.velocity.x));
		myAnim.SetFloat ("Vertical", Mathf.Abs(myRigidBody.velocity.y));
		myAnim.SetBool("isRunning", false);
		}
		else if(onLand)
		{
			myAnim.SetBool("isRunning", true);
			myAnim.SetFloat("Vertical",0);
			myAnim.SetFloat ("Speed", Mathf.Abs(myRigidBody.velocity.x));

		}
		else
		{
			
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
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, horizontalSpeed, 0f);
		} else if (Input.GetAxis ("Vertical") < 0f) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -horizontalSpeed, 0f);
		}
		// if(Input.GetAxisRaw ("Horizontal") > 0f && Input.GetAxisRaw ("Vertical") > 0f)
		// {
		// 	transform.localScale = new Vector3(1f,1f,1f);
		// 	myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, horizontalSpeed, 0f);
		// 	movePlayer ();
		// }
		// if(Input.GetAxisRaw ("Horizontal") > 0f && Input.GetAxis ("Vertical") < 0f)
		// {
		// 	transform.localScale = new Vector3(1f,1f,1f);
		// 	myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -horizontalSpeed, 0f);
		// 	movePlayer ();

		// }
		// if(Input.GetAxisRaw ("Horizontal") < 0f && Input.GetAxisRaw ("Vertical") > 0f)
		// {
		// 	myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, horizontalSpeed, 0f);
		// 	transform.localScale = new Vector3(-1f,1f,1f);
		// 	movePlayer ();

		// }
		// if(Input.GetAxisRaw ("Horizontal") < 0f && Input.GetAxis ("Vertical") < 0f)
		// {
		// 	myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -horizontalSpeed, 0f);
		// 	transform.localScale = new Vector3(-1f,1f,1f);
		// 	movePlayer ();

		// }

		if(Input.GetButtonDown("Jump") && !rushing ){
			rushing = true;
			speedMod = 2;
			Instantiate (bubbles, gameObject.transform.position, gameObject.transform.rotation);
			movePlayer ();
		}	
	}

	void movePlayer(){
		if (transform.localScale.x == 1) {
			myRigidBody.velocity = new Vector3 (horizontalSpeed + speedMod, myRigidBody.velocity.y, 0f);	
		} else {
			myRigidBody.velocity = new Vector3 (- (horizontalSpeed + speedMod), myRigidBody.velocity.y, 0f);
		}	
	}

	void resetBoostTime(){
		if (timeLeft <= 0) {
			timeLeft = 2f;
			rushing = false;
			speedMod = 0;
		} else if(rushing) {
			timeLeft -= Time.deltaTime;
		}	
	}

	public void hurt(){
		if(!rushing){
			gameObject.GetComponent<Animator> ().Play ("PlayerHurt");		
		}

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
}

