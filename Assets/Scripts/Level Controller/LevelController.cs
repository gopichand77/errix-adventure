using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public bool Intro =  false;
    public string levelName;
    void Start()
    {
        if(Intro)
        {
            NextLevel();
        }

    }
    
    public void NextLevel()
    {
       SceneManager.LoadSceneAsync(levelName);
    }
}

