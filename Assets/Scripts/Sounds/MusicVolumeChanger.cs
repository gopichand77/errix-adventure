using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicVolumeChanger : MonoBehaviour {

    // Reference to Audio Source component
    private AudioSource audioSrc;
    public Sprite MusicOff;
    public Sprite MusicOn;
    public GameObject Music;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;

	// Use this for initialization
	void Start () {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
       
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
        if(audioSrc.volume < 0.1)
        {
            Music.gameObject.GetComponentInChildren<Image> ().sprite = MusicOff;
            Debug.Log("Volume is "+musicVolume);
            
        }
        else{
            Music.gameObject.GetComponentInChildren<Image> ().sprite = MusicOn;
            
        }
        
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}