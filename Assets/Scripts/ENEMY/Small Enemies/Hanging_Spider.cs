using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging_Spider : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inRange;
    public Transform player;
    public float Range;
    public float shootRange = 5;
    float shootTimer;
    public float shootCoolDown = 0.5f;
    public bool canShoot = true;
    public GameObject ThrowObject;


    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
    }
    void Update()
    {
        Shoot();
        Range = Vector2.Distance(transform.position, player.position);
        if (Range < shootRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

    }
    private void Shoot()
    {
        if (inRange)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCoolDown)
            {
                canShoot = true;

                shootTimer = 0;

                if (canShoot)
                {
                    Vector2 Obj = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.5f);
                    GameObject thr = (GameObject)Instantiate(ThrowObject, Obj, transform.rotation);

                    canShoot = false;

                }
            }
        }
    }


}
