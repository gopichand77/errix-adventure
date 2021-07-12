using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem confetti;
    public string levelName;
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
    public void NextLevel()
    {
       SceneManager.LoadSceneAsync(levelName);
    }
    IEnumerator Level()
    {
        yield return new WaitForSeconds(2f);
        NextLevel();
    }
}
