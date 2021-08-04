using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSizeDecrease : MonoBehaviour
{
    // Start is called before the first frame update
        public float size = 6;
    private float defaultSize = 5;
    [SerializeField]
    Camera cam;

    private void Update()
    {
        if(cam.orthographicSize <  defaultSize )
            {
                CancelInvoke("DecreaseCam");
           
            }
            // if(cam.orthographicSize < defaultSize)
            // {
            //     CancelInvoke("DecreaseCam");
           
            // }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Player")){
            // cam.orthographicSize += 10 * Time.deltaTime;
            InvokeRepeating("DecreaseCam",0,0.03f);
        }
    }

    // private void OnTriggerStay2D(Collider2D collider2D) {
    //     if(collider2D.gameObject.CompareTag("Player")){
    //         // cam.orthographicSize += 10 * Time.deltaTime;
    //         InvokeRepeating("IncreaseCam",0,0.03f);
    //     }
    // }
    
    // private void OnTriggerExit2D(Collider2D trig)
    // {
    //       InvokeRepeating("DecreaseCam",0,0.03f);
        
    // }
    void IncreaseCam()
    {
        cam.orthographicSize += 0.01f;
    }
     void DecreaseCam()
    {
        cam.orthographicSize -= 0.01f;

    }
}
