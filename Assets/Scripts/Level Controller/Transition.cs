using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Transition : MonoBehaviour
{
    // public string Hai;
    public Scene scene;

    public void GoToNextLevelTran(string nameOfLevel)
    {
        SceneManager.LoadSceneAsync("Loading Screen");
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Scene());
    
     IEnumerator Scene()
    {
        yield return  new WaitForSeconds(1.8f);
        SceneManager.LoadSceneAsync(nameOfLevel);
        Destroy(gameObject);

       
    }
    }
    public void Restart()
    {
        scene =  SceneManager.GetActiveScene();
         SceneManager.LoadSceneAsync("Loading Screen");
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Scene1());
   IEnumerator Scene1()
    {
        yield return  new WaitForSeconds(1.8f);
        SceneManager.LoadScene(scene.name);
        Destroy(gameObject);

       
    }
    
    }
  
}