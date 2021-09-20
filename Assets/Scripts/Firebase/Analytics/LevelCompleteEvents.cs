using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using UnityEngine.SceneManagement;

public class LevelCompleteEvents : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GLevel1(){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
        Debug.Log("GLevel1");
    }

    public void GLevel2(){
        FirebaseAnalytics.LogEvent("GLevel2");
        Debug.Log("GLevel2");
    }
    public void GLevel3(){
        FirebaseAnalytics.LogEvent("GLevel3");
        Debug.Log("GLevel3");
    }
    public void GLevel4(){
        FirebaseAnalytics.LogEvent("GLevel4");
        Debug.Log("GLevel4");
    }
    public void GLevel5(){
        FirebaseAnalytics.LogEvent("GLevel5");
        Debug.Log("GLevel5");
    }
    public void GLevel6(){
        FirebaseAnalytics.LogEvent("GLevel6");
        Debug.Log("GLevel6");
    }
    public void GLevel7(){
        FirebaseAnalytics.LogEvent("GLevel7");
        Debug.Log("GLevel7");
    }
    public void GLevel8(){
        FirebaseAnalytics.LogEvent("GLevel8");
        Debug.Log("GLevel8");
    }
    public void GLevel9(){
        FirebaseAnalytics.LogEvent("GLevel9");
        Debug.Log("GLevel9");
    }
    public void GLevel10(){
        FirebaseAnalytics.LogEvent("GLevel10");
        Debug.Log("GLevel10");
    }



}
