using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.Events;



public class AdMObScript : MonoBehaviour
{


    //THE SCRIPT HAS ORIGNAL ID'S OF ADMOB
    InterstitialAd interstitial;
    RewardedAd rewarded;
    public UnityEvent UnityEvent;
    public UnityEvent loading;
    public GameObject Loading;
    BannerView bannerView;
    public bool Ads;
    bool  interstitialLoad;
    public bool respawn;
    bool  rewardlLoad;
    // Use this for initialization
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
        RequestInterstitial();
    }
     
    
    private void Update()
    {
        if (PlayerPrefs.HasKey("RemoveAds") == false)
        {
            Ads = true;
        }
        else
        {
            Ads = false;
            bannerView.Hide();
        }
        // rewarded.OnAdDidRecordImpression += 
    }
    
    public void RequestInterstitial()
    {
        // string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        // string adUnitId = "ca-app-pub-9793616844322643/1584681548";
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9793616844322643/1584681548"; // main
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-9793616844322643/9909383375";
#endif
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        interstitial.OnAdLoaded += HandleOnAdLoadedinter;
        // interstitial.OnAdLoaded += Loaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;


    }
    
    public void RequestBanner()
    {
       
        // replace this id with your orignal admob id for banner ad
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9793616844322643/9518309551";
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-9793616844322643/1753685390";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        if (PlayerPrefs.HasKey("RemoveAds") == false)
        {
            
            bannerView.LoadAd(request);
            bannerView.OnAdLoaded += HandleOnAdLoaded;
        }
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
            UnityEvent.Invoke();
        }
       
    }
      public void RequestRewaded()
    {
        // string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9793616844322643/4149318449"; // main
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-9793616844322643/3448279163";
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
         
       
       void RewardLoaded(object a, EventArgs args)
    {
        rewarded.Show();
        rewardlLoad = true;
    }
      public void HandleOnAdClosed(object sender, EventArgs args)
    {
        UnityEvent.Invoke();
        
        Debug.Log("Ad Closed");

        //do this when ad is closed
    }

    void Loaded(object a, EventArgs args)
    {
        interstitialLoad = true;
    }

   
     void AdFailed(object a, EventArgs args)
    {
        loading.Invoke();
    }
    void FailedtoLoad()
    {
        Loading.SetActive(true);
    }
 
 public void ShowInterstitial()
    {
        interstitial.Show();
      
        if(!interstitialLoad)
    {
        RequestInterstitial();

    }
        

        // RequestInterstitial();
        if (PlayerPrefs.HasKey("RemoveAds") == false)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
    }
 
    void HandleOnAdLoaded(object a, EventArgs args)
    {
        // interstitial.Show
        if (PlayerPrefs.HasKey("RemoveAds") == false)
        {
            print("loaded");
            bannerView.Show();

        }

        // interstitial.Show();
    }
    void HandleOnAdLoadedinter(object a, EventArgs args)
    {
        // interstitial.Show
        if (PlayerPrefs.HasKey("RemoveAds") == false)
        {
            print("loaded");
            interstitial.Show();

        }

        // interstitial.Show();
    }

public void HandleOnAdFailedToLoad(object sender , EventArgs args)
    {
        Debug.Log("Ad Failed");
          FailedtoLoad();
        //do this when ad fails to load
    }

//    public void HandleOnAdClosed(object sender, EventArgs args)
//     {
//         UnityEvent.Invoke();
        
//         Debug.Log("Ad Closed");

//         //do this when ad is closed
//     }
    

}

