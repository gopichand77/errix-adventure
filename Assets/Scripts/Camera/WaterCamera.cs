using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCamera : MonoBehaviour
{
    [SerializeField]
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + 2.5f, 0, -10);
    }
}
