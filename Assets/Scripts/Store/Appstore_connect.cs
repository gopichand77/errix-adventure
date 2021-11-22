#if UNITY_IOS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
public class Appstore_connect : MonoBehaviour
{
    public string achievement1 = "coinmaster";
     void Start () {
         GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
        // Authenticate and register a ProcessAuthentication callback
        // This call needs to be made before we can proceed to other calls in the Social API
        Social.localUser.Authenticate (ProcessAuthentication);
    }

    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    void ProcessAuthentication (bool success) {
        if (success) {
            Debug.Log ("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements (ProcessLoadedAchievements);
        }
        else
            Debug.Log ("Failed to authenticate");
    }
    
    public void AchievementDone()
    { 
        Social.ReportProgress(achievement1,100.0, (bool success)=>
        {
            if(success)
            {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            }
            else
            {
                
            }

        });
        
    
         
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements (IAchievement[] achievements) {
        if (achievements.Length == 0)
            Debug.Log ("Error: no achievements found");
        else
            Debug.Log ("Got " + achievements.Length + " achievements");
     
        // You can also call into the functions like this
        Social.ReportProgress (achievement1, 100.0, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
       
    }
}
#endif