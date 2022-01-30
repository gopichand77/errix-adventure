using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private Animator anim;
    Transform player;
    public Transform firepoint;
    public GameObject Pea;
    public float playerDist;
     float targetDist;
    public bool check = false;
    // public float playerDist;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetDist = Vector2.Distance( player.transform.position, transform.position);
        if(playerDist > targetDist)
        {
            anim.SetBool("Attack", true);
            check =true;
        }
        else{
            anim.SetBool("Attack", false);
            check = false;
        }
    }
    public void Shoot()
    {
         Instantiate(Pea, firepoint.position, firepoint.rotation);
    }
}
