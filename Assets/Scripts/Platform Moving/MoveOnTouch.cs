using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{

    public float dirX, moveSpeed = 3f;
    bool moveRight = true;
    

    void Update() {
        if (transform.position.x > 8f){
            moveRight = false;
        }
        if (transform.position.x < -2f){
            moveRight =true;
        }

        if (moveRight) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        }
        else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }


    [SerializeField]
    private Vector3 velocity;
    private bool moving;

    private void OnCollisionEnter2D(Collision2D collision) {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player){
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        
            collision.collider.transform.SetParent(null);
        
    }

    private void FixedUpdate(){
        if(moving){
            transform.position += (velocity* Time.deltaTime);
        }
    }
}
