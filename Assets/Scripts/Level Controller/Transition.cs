using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Transition : MonoBehaviour
{
    public string listofWorld;
   
   
    

    // Update is called once per frame
    public void LevelWithTrans()
    {
        SceneManager.LoadSceneAsync("Loading Screen");
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Scene());
    }
     IEnumerator Scene()
    {
        yield return  new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(listofWorld);
        Destroy(gameObject);
    }
    
  
}
