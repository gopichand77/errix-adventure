using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPos;
    private float yPos, yLength;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        yPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        // yLength = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float repeat = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(repeat > startPos + length) {
            startPos += length;
        } 
        else if(repeat < startPos - length) {
            startPos -= length;
        }
    }
}
