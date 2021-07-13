using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem confetti;
    public GameObject Trnasition;
    public GameObject ControlPanles;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Done",true);
            confetti.Play();
            StartCoroutine(Level());
        }
    }
    
    IEnumerator Level()
    {
        yield return new WaitForSeconds(2f);
        Trnasition.gameObject.SetActive(true);
        ControlPanles.SetActive(false);
        
    }
}
