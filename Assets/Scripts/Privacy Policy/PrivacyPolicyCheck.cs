using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicyCheck : MonoBehaviour
{

    private string policykey = "policy";
    [SerializeField]
    GameObject privacyPanel;
    // Start is called before the first frame update
    void Start()
    {
        var accepted = PlayerPrefs.GetInt(policykey, 0) == 1;

        if(accepted)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
