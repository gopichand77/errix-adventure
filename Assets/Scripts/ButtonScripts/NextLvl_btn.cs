using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextLvl_btn : MonoBehaviour
{
    internal Transition trans;
    internal Button bttn;
    public string nameLevel;
    public bool h;
    AdMObScript adMObScript;
    // Start is called before the first frame update
    void Start()
    {
        adMObScript = gameObject.GetComponent<AdMObScript>();
        trans =  FindObjectOfType<Transition>();
        bttn =  gameObject.GetComponent<Button>();
        
        // bttn.onClick.AddListener(L);
    }
    public void L()
    {
        h = true;
        bttn.onClick.RemoveAllListeners();
        // bttn.onClick.AddListener(()=> trans.GoToNextLevelTran(nameLevel));
        // trans.GoToNextLevelTran(nameLevel);
    }
    public void i()
    {
        PlayerPrefs.DeleteAll();
        h = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(h)
        {
            adMObScript.enabled =  false;
            bttn.onClick.RemoveAllListeners();
            bttn.onClick.AddListener(i);
        }
            
        
       
        
    }
}
