using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public string listofWorld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void LevelWithTrans()
    {
       SceneManager.LoadSceneAsync(listofWorld);
    }
}

