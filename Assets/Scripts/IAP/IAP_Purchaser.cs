using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Purchaser : MonoBehaviour
{

    public void RemoveAds()
    {
        if(PlayerPrefs.HasKey("RemoveAds") ==  false)
        {
            PlayerPrefs.SetInt("RemoveAds",0);
        }
    }
}
