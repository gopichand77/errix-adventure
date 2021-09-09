using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using System;
public class CheckInternet : MonoBehaviour
{
    [SerializeField] GameObject loadingText;
    [SerializeField] GameObject connectionErrorText;
    [SerializeField] GameObject tryAgainButton;
    [SerializeField] GameObject playButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternetConnection());
    }
    
    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://errix.co");
        yield return request.SendWebRequest();
        yield return new WaitForSeconds(0.1f);

        // if (request.error != null)
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingText.gameObject.SetActive(false);
            connectionErrorText.gameObject.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Play(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
