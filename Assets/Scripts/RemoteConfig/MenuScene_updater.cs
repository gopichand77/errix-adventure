using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
public class MenuScene_updater : MonoBehaviour
{

        public int Menuvalue = 0;
        public GameObject Winter;
        public GameObject Autumn;
        public GameObject Grassland;
    // Declare any Settings variables you’ll want to configure remotely:

    // Start is called before the first frame update
       void Awake () {
        // Add a listener to apply settings when successfully retrieved:
        ConfigManager.FetchCompleted += ApplyRemoteSettings;

        // Set the user’s unique ID:
        ConfigManager.SetCustomUserID("some-user-id");

        // Set the environment ID:
        ConfigManager.SetEnvironmentID("d793b738-a207-4a1b-8b39-06599eca7fa0");

        // Fetch configuration setting from the remote service:
   
    }


    // Update is called once per frame
    void ApplyRemoteSettings (ConfigResponse configResponse) {
        // Conditionally update settings, depending on the response's origin:
        switch (configResponse.requestOrigin) {
            case ConfigOrigin.Default:
                Debug.Log ("No settings loaded this session; using default values.");
                break;
            case ConfigOrigin.Cached:
                Debug.Log ("No settings loaded this session; using cached values from a previous session.");
                break;
            case ConfigOrigin.Remote:
                Debug.Log ("New settings loaded this session; update values accordingly.");
                Menuvalue = ConfigManager.appConfig.GetInt ("Value");
             
                // assignmentId = ConfigManager.appConfig.assignmentId;
                break;
        }
    }
    void Update()
    {
        ConfigManager.FetchCompleted += ApplyRemoteSettings;
        if(Menuvalue == 1)
        {
            Winter.SetActive(true);
            Autumn.SetActive(false);
            Grassland.SetActive(false);
        }
        if(Menuvalue == 2)
        {
            Grassland.SetActive(true);
            Winter.SetActive(false);
            Autumn.SetActive(false);

        }
        if(Menuvalue == 3)
        {
            Autumn.SetActive(true);
            Winter.SetActive(false);
            Grassland.SetActive(false);
        }

    }
}
