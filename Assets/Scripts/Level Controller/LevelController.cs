using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string ListofWorld;
    Touch touch;
    // Start is called before the first frame update
    

    // Update is called once per frame
   
    public void GoNextLevel()
    {
        SceneManager.LoadScene(ListofWorld);

    }
}