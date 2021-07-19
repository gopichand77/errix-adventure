using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollections : MonoBehaviour
{

    //=========================================================================================//

    [SerializeField]
    Player playerScript;

    public int Bullets;//We Can keep these as internal to hide from Unity 
    public int goldCoins;// To hide Change public to internal From Unity
    public int gems;
    public int Keys;
    public int openChests;
    [Header("UI Elements")]
    public Text goldCoinScoreText;
    public Text gemsScoreText;
    public Text keysText;
    public Text treasureOpenedText;
    public Text noOfBulletsText;
    public Text PanelgoldCoinScoreText;
    public Text PanelgemsScoreText;
    public Text PaneltreasureOpenedText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        goldCoinScoreText.text = ""; //goldcoins
        gemsScoreText.text = ""; //gems
        keysText.text = ""; //keys
        treasureOpenedText.text = "";//Treasures opened
        noOfBulletsText.text = ""; //bullets
        PaneltreasureOpenedText.text = "";
        PanelgoldCoinScoreText.text = "";
        PanelgemsScoreText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
         goldCoinScoreText.text = "" + goldCoins;//working
        gemsScoreText.text = "" + gems;//not working
        keysText.text = "" + Keys;//working
        noOfBulletsText.text = "" + Bullets;// working
        treasureOpenedText.text = "" + openChests;
        PaneltreasureOpenedText.text = "" + openChests;
        PanelgoldCoinScoreText.text = "" + goldCoins;
        PanelgemsScoreText.text = "" + gems;
        
    }
    internal void NoofGoldCoins()
    {
        goldCoins = goldCoins + 1;
    }
    internal void NoOfAxes(int NoOfAxes1)
    {
        Bullets += NoOfAxes1;
    }
    internal void NoofKeys(int NoofKeys1)
    {
        Keys += NoofKeys1;
    }
    internal void OpenTreasure(int NoofCoins1)
    {
        Keys -= 1;
    }
    internal void ChestOpen()
    {
        openChests = openChests + 1;
    }
    internal void NoOfgems()
    {
        gems = gems + 1;
    }
    internal void BulletHandler()
    {
        Bullets -= 1;
    }

}
