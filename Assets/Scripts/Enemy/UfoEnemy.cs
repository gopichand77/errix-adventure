using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoEnemy : MonoBehaviour
{
    public float horizontalSpeed = 0;
    public float VerticalSpeed;
    public float amplitude;
    public float desiredPostionY;
    public bool movingRight;
    public Vector3 tempPosition;
    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude + desiredPostionY;
        transform.position = tempPosition;
        if (movingRight)
        {
            horizontalSpeed = 0.01f;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {

            horizontalSpeed = -0.01f;
            transform.localScale = new Vector2(-1, 1);
        }


    }
    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }

        }

    }
}
