using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem confetti;
    public GameObject transitionPanel;
    private GameObject controlPanel;
    SingleLevel levelDone;
    private int currentStarsNum = 0;
    public int levelIndex;
    // Start is called before the first frame update
    private void Start()
    {
        confetti =  transform.GetChild(0).GetComponentInChildren<ParticleSystem>();
        controlPanel =  GameObject.Find("Controls Panel");
        // transitionPanel = GameObject.Find("Grasslands Next Level Panel");
        levelDone =  FindObjectOfType<SingleLevel>();
    }
    private void Update()
    {
        // transitionPanel = GameObject.Find("Grasslands Next Level Panel");
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Done",true);
            // confetti.Play();
            StartCoroutine(ConfettiPlay());
            StartCoroutine(Level());
            PressStarsButton();
        }
    }
    
    IEnumerator Level()
    {
        yield return new WaitForSeconds(5);
        transitionPanel.gameObject.SetActive(true);
        controlPanel.SetActive(false);
        
    }

    IEnumerator ConfettiPlay(){
        confetti.Play();
        yield return new WaitForSeconds(4);
        confetti.Stop();
    }
    public void PressStarsButton()
    {
        currentStarsNum = levelDone.currentStarsNum;

        if(currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelDone.currentStarsNum);
        }

        //BackButton();
        //MARKER Each level has saved their own stars number
        //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, levelDone.currentStarsNum));

     
    }

}
