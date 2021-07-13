using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Transition : MonoBehaviour
{
    public string nameOfLevel;

    public void GoToNextLevelTran()
    {
        SceneManager.LoadSceneAsync("Loading Screen");
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Scene());
    }
     IEnumerator Scene()
    {
        yield return  new WaitForSeconds(1.8f);
        SceneManager.LoadSceneAsync(nameOfLevel);
        Destroy(gameObject);
    }
    
  
}
