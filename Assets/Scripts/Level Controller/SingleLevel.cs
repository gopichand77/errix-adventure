using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{   
    [Header("Only for Testing")]
    public int currentStarsNum = 0;
   

    public void BackButton()
    {
        SceneManager.LoadScene("Grasslands Level Selector");
    }

    public void PressStarsButton(int _starsNum)
    {
        currentStarsNum += 1;

        // if(currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        // {
        //     PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        // }

        // //BackButton();
        // //MARKER Each level has saved their own stars number
        // //CORE PLayerPrefs.getInt("KEY", "VALUE"); We can use the KEY to find Our VALUE
        // Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsNum));

        
    }

}
