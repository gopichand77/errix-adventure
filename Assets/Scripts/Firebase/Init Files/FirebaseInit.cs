using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;

public class FirebaseInit : MonoBehaviour
{

    public static bool firebaseReady;

    // Start is called before the first frame update
    void Start()
    {
        // FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        // {
        //     FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        //     // var app = FirebaseApp.DefaultInstance;
        // });

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;
                firebaseReady = true;// added from the web
                Debug.Log("Firebase is ready for use."); // added from the web

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                firebaseReady = false; // added from the web
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }
}
