using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextLvl_btn : MonoBehaviour
{
    internal Transition trans;
    internal Button bttn;
    public string nameLevel;
    // Start is called before the first frame update
    void Start()
    {
        trans =  FindObjectOfType<Transition>();
        bttn =  gameObject.GetComponent<Button>();
        bttn.onClick.AddListener(()=> trans.GoToNextLevelTran(nameLevel));
        // bttn.onClick.AddListener(L);
    }
    public void L()
    {
        // trans.GoToNextLevelTran(nameLevel);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
