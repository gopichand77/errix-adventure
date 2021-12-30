using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private Player player;
    public GameObject[] PrefferedObject;
    public AudioSource audioSource;
    // public Transform PrefferedObject;
    private bool Opened = true;
    SingleLevel levelDone;
    int randomObject;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        levelDone =  FindObjectOfType<SingleLevel>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenChest()
    {
        if (player.Collectables.Keys > 0 && Opened)
        {
            audioSource.Play();
            levelDone.currentStarsNum +=1 ;
            player.Collectables.Keys -= 1;
            anim.SetBool("Open", true);
            player.Collectables.ChestOpen();
            randomObject = Random.Range(0, PrefferedObject.Length);
            Instantiate(PrefferedObject[randomObject], transform.position, Quaternion.identity);

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
