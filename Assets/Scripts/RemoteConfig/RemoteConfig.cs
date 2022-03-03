using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
public class RemoteConfig : MonoBehaviour
{
//         public struct userAttributes {
//       // Optionally declare variables for any custom user attributes:
//         public bool expansionFlag;
//     }

//     public struct appAttributes {
//       // Optionally declare variables for any custom app attributes:
//         public int level;
//         public int score;
//         public string appVersion;
//     }

//     // Optionally declare a unique assignmentId if you need it for tracking:
//     public string assignmentId;

//     // Declare any Settings variables you’ll want to configure remotely:
//     public int enemyVolume;
//     public bool enemyHealth;
//     public float enemyDamage; 
//     // Start is called before the first frame update
//    void Awake () {
//         // Add a listener to apply settings when successfully retrieved:
//         ConfigManager.FetchCompleted += ApplyRemoteSettings;

//         // Set the user’s unique ID:
//         ConfigManager.SetCustomUserID("some-user-id");

//         // Set the environment ID:
//         ConfigManager.SetEnvironmentID("d793b738-a207-4a1b-8b39-06599eca7fa0");

//         // Fetch configuration setting from the remote service:
//         ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
//     }

//     void ApplyRemoteSettings (ConfigResponse configResponse) {
//         // Conditionally update settings, depending on the response's origin:
//         switch (configResponse.requestOrigin) {
//             case ConfigOrigin.Default:
//                 Debug.Log ("No settings loaded this session; using default values.");
//                 break;
//             case ConfigOrigin.Cached:
//                 Debug.Log ("No settings loaded this session; using cached values from a previous session.");
//                 break;
//             case ConfigOrigin.Remote:
//                 Debug.Log ("New settings loaded this session; update values accordingly.");
//                 enemyVolume = ConfigManager.appConfig.GetInt ("Value");
//                 enemyHealth = ConfigManager.appConfig.GetBool ("Winter");
//                 enemyDamage = ConfigManager.appConfig.GetFloat ("enemyDamage");
//                 // assignmentId = ConfigManager.appConfig.assignmentId;
//                 break;
//         }
//     }

}
