using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenShot : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenCapture.CaptureScreenshot("/Users/gopichand/Desktop/testimages/img.png");
        }
    }
}
