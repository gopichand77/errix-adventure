using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashtoMenu : MonoBehaviour
{
    [SerializeField] string menu;
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer(){
        yield return new WaitForSeconds(4.8f);
        GoNextLevel();
    }
    void GoNextLevel()  
    {
        SceneManager.LoadSceneAsync(menu);
    }
}