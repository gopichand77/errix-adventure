using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
public class AdMobRewardedAd : MonoBehaviour
{
    public UnityEvent loading;
    private Player player;
    public bool respawn;
    RewardedAd rewarded;
    bool  rewardlLoad;
    private Button button;
    public UnityEvent UnityEvent;
    // Start is called before the first frame update
    void Start()
    {
        button =  gameObject.GetComponent<Button>();
        player =  FindObjectOfType<Player>();
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        UnityEvent.AddListener(player.Revive);
        button.onClick.AddListener(showRewarded);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void showRewarded()
    {
         if(!rewardlLoad)
    {
        // RequestInterstitial();
        RequestRewaded();

    }
        
        if (rewarded.IsLoaded())
        {
            rewarded.Show();
        }
        rewarded.OnAdClosed+= Respawn;

    }
      public void RequestRewaded()
    {
        // string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9793616844322643/4149318449"; // main
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-9793616844322643/9909383375";
#endif

        // string adUnitId = "	ca-app-pub-3940256099942544/5224354917";
        // Initialize an InterstitialAd.
        rewarded = new RewardedAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        rewarded.LoadAd(request);
        rewarded.OnAdFailedToLoad += AdFailed;
        rewarded.OnAdLoaded += RewardLoaded;
        rewarded.OnAdClosed += HandleOnAdClosed;
        
        // AdRequest request = new AdRequest.Builder()
    }
         void AdFailed(object a, EventArgs args)
    {
        loading.Invoke();
    }
        void Respawn(object a, EventArgs args)
    {
        respawn = true;
        UnityEvent.Invoke();
        
    }
       void RewardLoaded(object a, EventArgs args)
    {
        rewardlLoad = true;
    }
      public void HandleOnAdClosed(object sender, EventArgs args)
    {
        UnityEvent.Invoke();
        
        Debug.Log("Ad Closed");

        //do this when ad is closed
    }
}
