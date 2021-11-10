using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextUpdate : MonoBehaviour
{
    public Text goldCoinScoreText;
    public Text gemsScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldCoinScoreText.text = ""+PlayerPrefs.GetInt("Coins");
        gemsScoreText.text = ""+PlayerPrefs.GetInt("gems");
    }
}
