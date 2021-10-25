using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class GPGS_SERVICES : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    // Start is called before the first frame update
    void Start()
    {
        if(platform == null)
        {
            PlayGamesClientConfiguration config  = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success => 
        {
            if(success)
            {
                Debug.Log("Log is Successful");
               
            }
             else
                {
                    Debug.Log("Failed to log in");
                }

        });
    }

}
