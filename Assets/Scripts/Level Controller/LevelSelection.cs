using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using EasyUI.Toast;
public class LevelSelection : MonoBehaviour
{
    
    [SerializeField] private bool unlocked =  false;//Default value is false;
    public Image unlockImage;
    public GameObject[] stars;
    // public bool Loaded =  false;
    public Button button;
    public Sprite starSprite;
    public Transition trans;
    public string nameLevel;
        private void Start()
    {
        trans = FindObjectOfType<Transition>();
        // nameLevel = "Grassland Level1";
        button =  gameObject.GetComponent<Button>();
        
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        
        
        UpdateLevelImage();//TODO MOve this method later
        UpdateLevelStatus();//TODO MOve this method later
    }

    private void UpdateLevelStatus()
    {
        // UnityAction<string> mbListener = new UnityAction(trans.GoToNextLevelTran)
        //if the current lv is 5, the pre should be 4
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > 0)//If the firts level star is bigger than 0, second level can play
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else//if unlock is true means This level can play !
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

    public void PressSelection()//When we press this level, we can move to the corresponding Scene to play
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if(unlocked )
        {
            // t mbl =   trans.GoToNextLevelTran(nameLevel);
            trans.GoToNextLevelTran(nameOfLevel: nameLevel);
            // button.onClick.AddListener(trans.GoToNextLevelTran(nameLevel));
            
        }
        else if(!unlocked)
        {
            Toast.Show("Please complete" +  previousLevelNum, 1.5f, new Color(0f,0f,0f,0f));

        }
       
    }
}