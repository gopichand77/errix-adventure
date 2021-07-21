using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class UndergroundVisible : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;
    private float alphaValue;
    
    // Start is called before the first frame update
    void Start()
    {
        tilemap = gameObject.GetComponent<Tilemap>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            tilemap.color = new  Color(1f, 1f, 1f, 0.4f);
            // InvokeRepeating("IncreaseAlpha",0,0.03f);


        }
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
         if(trig.gameObject.CompareTag("Player"))
        {
            tilemap.color = new  Color(1f, 1f, 1f, 1f);
            // InvokeRepeating("IncreaseAlpha",0,0.03f);


        }
    }
    // void IncreaseAlpha()
    // {
    //     alphaValue -= 0.001f;

    // }
}
