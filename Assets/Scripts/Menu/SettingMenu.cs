using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public Canvas TitleCanvas;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
   
   public void Setting()
   {
       SettingsMenu.SetActive(true);
       TitleCanvas.gameObject.SetActive(false);
   } 
    public void Back()
   {
       SettingsMenu.SetActive(false);
       TitleCanvas.gameObject.SetActive(true);
   } 
    public void Quit()
   {
       Application.Quit();
   } 

}
