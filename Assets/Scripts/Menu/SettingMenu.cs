using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject pauseMenu;
    // Start is called before the first frame update
   
   public void Setting()
   {
       pauseMenu.SetActive(true);
       titleCanvas.gameObject.SetActive(false);
   } 
    public void Back()
   {
       pauseMenu.SetActive(false);
       titleCanvas.SetActive(true);
   } 
    public void Quit()
   {
       Application.Quit();
   } 

}
