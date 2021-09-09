using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
public class AdMObScript : MonoBehaviour
{
    InterstitialAd interstitial;
    string interstitialId;
    void Start()
    {
        RequestInterstitial();
    }

    void RequestInterstitial()
    {

#if UNITY_ANDROID
        interstitialId = "ca-app-pub-3940256099942544/8691691433";// Test Ads
        // interstitialId = "ca-app-pub-9793616844322643/7816189618";// Mian
        
#elif UNITY_IPHONE
        interstitialId = "ca-app-pub-3940256099942544/1033173712";// Test Ads
        //interstitialId = "ca-app-pub-9793616844322643/9909383375" // Mian 
#else
        interstitialId = null;
#endif
        interstitial = new InterstitialAd(interstitialId);

        //call events
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdOpening += HandleOnAdOpened;
        interstitial.OnAdClosed += HandleOnAdClosed;
        // interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        //create and ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request); //load & show the banner ad
        } else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            interstitial.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }

    //show the ad
    public void ShowInterstitial()
    {
         RequestInterstitial();
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }


    //events below
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        //do this when ad fails to load
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //do this when ad is opened
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //do this when on leaving application;
    }
}
