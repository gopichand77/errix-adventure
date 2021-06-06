using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_resize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 16/ 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
