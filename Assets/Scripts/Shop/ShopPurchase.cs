using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPurchase : MonoBehaviour
{
    public static int coins;
    public static int gems;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Convert()
    {
        // coins = PlayerPrefs.GetInt("Coins");
        // gems = PlayerPrefs.GetInt("gems");
        if(PlayerPrefs.GetInt("gems")< 1)
       {
           
       }
        PlayerPrefsManager.gems = PlayerPrefsManager.gems   - 1;
        PlayerPrefsManager.coins = PlayerPrefsManager.coins + 10;
        PlayerPrefsManager.UpdateCoins();
        PlayerPrefs.Save();
    }
}
