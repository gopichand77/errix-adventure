using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Analytics;
public class LevelController : MonoBehaviour
{
    public bool Intro =  false;
    public string levelName;
    public Scene scene;
    void Start()
    {
        if(Intro)
        {
            NextLevel();
        }

    }
    
    public void NextLevel()
    {
        FirebaseAnalytics.LogEvent(scene.name);
       SceneManager.LoadSceneAsync(levelName);
    }
}

