using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicyCheck : MonoBehaviour
{

    private string policykey = "policy";
    private bool accepted;
    [SerializeField]
    GameObject privacyPanel;
    // Start is called before the first frame update
    void Start()
    {
        accepted = PlayerPrefs.GetInt(policykey, 0) == 1;
        Debug.Log(accepted);

        if(!accepted)
            return;
        off();
        onMenuClosed();
        
    }

    private void off(){
        privacyPanel.SetActive(false);
    }
    private void onMenuClosed()
    {
        Debug.Log("PrivacyPolicy Accepted");
        PlayerPrefs.SetInt(policykey, 1);
    }
    public void setPref()
    {
      PlayerPrefs.SetInt(policykey, 1);
      off();
        onMenuClosed();
      Debug.Log(accepted);

    }
    //  public void BackPref()
    // {
    //   PlayerPrefs.SetInt(policykey, 0);
    //   Debug.Log(accepted);

    // }


    // Update is called once per frame
    void Update()
    {
        
    }
}