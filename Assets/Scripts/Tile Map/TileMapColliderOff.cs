using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapColliderOff : MonoBehaviour
{
    TilemapRenderer tilemapRenderer; 
    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tilemapRenderer.enabled = false;
        
    }
}
