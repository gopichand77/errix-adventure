using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicyCheck : MonoBehaviour
{

    private string policykey = "policy";
    private bool accepted;
    [SerializeField]
    GameObject privacyPanel;
    [SerializeField]
    GameObject tapToPlay;
    // Start is called before the first frame update
    void Start()
    {
        accepted = PlayerPrefs.GetInt(policykey, 0) == 1;
        Debug.Log(PlayerPrefs.GetInt(policykey, 0) == 1);

        if (accepted)
        {
            off();
            // onMenuClosed();
            tapToPlay.SetActive(true);
        }
        else
        {
            tapToPlay.SetActive(false);
        }




    }

    private void off()
    {
        privacyPanel.SetActive(false);
    }
    private void onMenuClosed()
    {
        // Debug.Log("PrivacyPolicy Accepted");
        // PlayerPrefs.SetInt(policykey, 1);
    }
    public void setPref()
    {
        tapToPlay.SetActive(true);
        PlayerPrefs.SetInt(policykey, 1);
        off();
        onMenuClosed();
        Debug.Log(accepted);

    }
    public void BackPref()
    {
        PlayerPrefs.SetInt(policykey, 0);
        Debug.Log(accepted);

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt(policykey, 0) == 1);
    }
}