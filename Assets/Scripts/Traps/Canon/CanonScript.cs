using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject canonball;
    public float timebetween;
    public float starttimebetween = 2;
    // Start is called before the first frame update
    void Start() 
    {
        timebetween = starttimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebetween <= 0)
        {
            Instantiate(canonball, firepoint.position, firepoint.rotation);
            timebetween = starttimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
