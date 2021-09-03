using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public Player player;
    public Transform CoinPoint;
    public Transform PrefferedObject;
    private bool Opened = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenChest()
    {
        if (player.Collectables.Keys > 0 && Opened)
        {
            player.Collectables.Keys -= 1;
            anim.SetBool("Open", true);
            player.Collectables.ChestOpen();
            Instantiate(PrefferedObject, CoinPoint.position, CoinPoint.rotation);

            Opened = false;
            StartCoroutine(CollectTreasure());

        }


    }
    IEnumerator CollectTreasure()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

}
