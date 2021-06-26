using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureButton : Chest
{
    private Chest chest;
    // Start is called before the first frame update
    void Start()
    {
        //chest = gameObject.GetComponent<Chest>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Treasure()
    {
        OpenTreasure();


    }
}
