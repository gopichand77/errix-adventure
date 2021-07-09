using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class LevelController : MonoBehaviour
{
    public string listofWorld;
    public string LoadingScreen;
   
    

    // Update is called once per frame
    public void GoNextLevel()
    {
        SceneManager.LoadSceneAsync(LoadingScreen);
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Scene());
    }
     IEnumerator Scene()
    {
        
        
        yield return  new WaitForSeconds(2f);
        
        SceneManager.LoadSceneAsync(listofWorld);
       
     
    }
    
  
}
