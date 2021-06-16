using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundsVolumeChanger : MonoBehaviour {

    // Reference to Audio Source component
    private AudioSource audioSrc;
    public Sprite SoundOff;
    public Sprite SoundOn;
    public GameObject Sound;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float SoundsVolume = 1f;

	// Use this for initialization
	void Start () {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
       
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = SoundsVolume;
        if(audioSrc.volume < 0.1)
        {
            Sound.gameObject.GetComponentInChildren<Image> ().sprite = SoundOff;
            Debug.Log("Volume is "+ SoundsVolume);
            
        }
        else{
            Sound.gameObject.GetComponentInChildren<Image> ().sprite = SoundOn;
            
        }
        
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        SoundsVolume = vol;
    }
}