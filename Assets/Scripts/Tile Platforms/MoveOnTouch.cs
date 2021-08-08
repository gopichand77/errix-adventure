using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{

    public float  moveSpeed = 3f;
    bool moveRight = true;
    public float gridPos;
    [Header("Limits")]
    public float rightLimit;
    public float leftLimit;

    

    void Update() {
        if (transform.position.x - gridPos > rightLimit){
            moveRight = false;
        }
        if (transform.position.x - gridPos < -leftLimit){
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

    private void OnTriggerEnter2D(Collider2D trig) {
        Player player = trig.gameObject.GetComponent<Player>();
        if(player){
            moving = true;
            trig.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D trig){
            trig.gameObject.transform.SetParent(null);
    }

    private void FixedUpdate(){
        if(moving){
            transform.position += (velocity* Time.deltaTime);
        }
    }
}