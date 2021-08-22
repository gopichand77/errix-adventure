using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase;
using Firebase.Analytics;
public class Level_Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd);
    }
}
