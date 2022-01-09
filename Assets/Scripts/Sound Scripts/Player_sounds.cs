using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sounds : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject player;
    public bool played;
    // Start is called before the first frame update
    void Start()
    {
        played = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
         if(player.GetComponent<Player>().currentHealth <= 0 && !played)
        {
            audioSource.Play();
            played = true;

        }
        
    }
}
