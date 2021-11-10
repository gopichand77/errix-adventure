using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public const string Coins = "Coins";
    public static int coins;
    public int num;
     public const string Gems = "gems";
    public static int gems = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        gems = PlayerPrefs.GetInt("gems");


    }

    // Update is called once per frame
    void Update()
    {
        num = coins;

    }
    public static void UpdateCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
         PlayerPrefs.SetInt("gems", gems);
         gems = PlayerPrefs.GetInt("gems");
        coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.Save();
        // savePrefs();

    }
  
}
