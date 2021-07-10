using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public Player player;
    public Transform CoinPoint;
    public Transform GoldChest;
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
        if(player.Keys > 0 && Opened){
            player.Keys -=1;
        anim.SetBool("Open",true);
        player.ChestOpen();
        Instantiate(GoldChest,CoinPoint.position,CoinPoint.rotation);

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
