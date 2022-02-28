using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public GameObject ControlPanel;
    public GameObject pauseMenu;
    // Start is called before the first frame update
   private void Start()
   {
      ControlPanel =  GameObject.Find("Controls Panel");
    //   pauseMenu = GameObject.Find("Canvas/Pause Panel");
   }
  
   public void Setting()
   {
       pauseMenu.SetActive(true);
    //    ControlPanel.SetActive(false);
   } 
    public void Back()
   {
       pauseMenu.SetActive(false);
    //    ControlPanel.SetActive(true);
   } 
    public void Quit()
   {
       Application.Quit();
   } 

}
