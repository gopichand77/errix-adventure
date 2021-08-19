using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyManager : MonoBehaviour
{

    private string policykey = "policy";
    
    // Start is called before the first frame update
    void Start()
    {
        var accepted = PlayerPrefs.GetInt(policykey, 0) == 1;

        if(accepted)
            return;
        
        SimpleGDPR.ShowDialog(new TermsOfServiceDialog().
        SetPrivacyPolicyLink("https://errix.co/privacypolicy.html").
        SetTermsOfServiceLink("https://errix.co/terms&conditions.html"),
        onMenuClosed
        );

    }

    private void onMenuClosed(){
        Debug.Log("PrivacyPolicy Accepted");
        PlayerPrefs.SetInt(policykey, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
