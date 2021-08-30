using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingIntro : MonoBehaviour
{
    public float speed;
    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -20f) {
            transform.position = startPosition;
        }
    }
}
