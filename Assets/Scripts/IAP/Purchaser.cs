using System; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
    public class Purchaser : MonoBehaviour

{
    public enum PurchaseType { removeAds,Add};
    public PurchaseType purchaseType;
    
    public void ClickPurchaseButton()
    {
        switch(purchaseType)
        {
            case PurchaseType.removeAds:
                break;

        }
    }

    }
