// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class CircleTransition : MonoBehaviour
// {
//     [SerializeField] RectTransform FxHolder;
//     [SerializeField] Image CircleImg;
//     [SerializeField] Text txtProgress;

//     [SerializeField] [Range(0, 1)] float progress = 0f;

//     // public static CircleTransition instance;
//     // public GameObject loadingScreen;

//     // private void Awake() {
//     //     instance = this;

//     //     SceneManager.LoadSceneAsync((int)SceneIndexes.menu, LoadSceneMode.Additive);
//     // }

//     void Update()
//     {
//         CircleImg.fillAmount = progress;
//         txtProgress.text = Mathf.Floor(progress * 100).ToString() + "%";
//         FxHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -progress * 360));
//     }

//     // public void LoadGame() {
//     //     loadingScreen.gameObject.SetActive(true);
//     //     SceneManager.UnloadSceneAsync((int)SceneIndexes.menu);
//     //     SceneManager.LoadSceneAsync((int)SceneIndexes.listofworlds, LoadSceneMode.Additive);
//     // }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleTransition : MonoBehaviour
{
    [SerializeField] RectTransform FxHolder;
    [SerializeField] Image CircleImg;
    private AsyncOperation operation;
    
    [SerializeField] Text txtProgress;
    private Canvas canvas;

    //[SerializeField] [Range(0, 1)] float progress = 0f;
  
    private void Awake()
	{
		canvas = GetComponentInChildren<Canvas>(true);
		DontDestroyOnLoad(gameObject);
        
	}
   
    private void UpdateProgressUI(float progress)
    {
        CircleImg.fillAmount = progress;
        txtProgress.text = (int)(progress * 100f)+ "%";
    
    }
    public void LoadSceneAsync(string sceneName)
    {
        UpdateProgressUI(0);
        canvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));
    }
    private IEnumerator BeginLoad(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            UpdateProgressUI(operation.progress);

            yield return null;

            
        }
      

        UpdateProgressUI(operation.progress);
        operation = null;
        canvas.gameObject.SetActive(false);


    }
     
}
