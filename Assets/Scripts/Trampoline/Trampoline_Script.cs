using UnityEngine;
using System.Collections;

public class Trampoline_Script : MonoBehaviour {


	public bool customSpeed;
	public Vector2 customVelocity;
	public float multiplier;


	public bool onTop;
	public GameObject bouncer;
	Animator anim;
	Vector2 velocity;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}



	void OnCollisionStay2D(Collision2D other)
	{

		if (onTop) {
						
						bouncer = other.gameObject;
				}

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<PlayerMovement>().moveSpeed = velocity.x;
				}
		
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        
    }


	void OnTriggerEnter2D()
	{
		onTop = true;
	}
	void OnTriggerExit2D()
	{
        
		onTop = false;
		anim.SetBool ("Jump", false);
        bouncer.gameObject.GetComponent<PlayerMovement>().moveSpeed = 7;

		}

	void OnTriggerStay2D()
	{
		onTop = true;
        anim.SetBool ("Jump", true);
	}
		
		
	void Jump()
	{

		if (customSpeed)
						velocity = customVelocity;
				else
						velocity = transform.up * multiplier;



		bouncer.GetComponent<Rigidbody2D>().velocity = velocity;

		}


		
	}
