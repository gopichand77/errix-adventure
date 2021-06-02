using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleTransition : MonoBehaviour
{
    [SerializeField] RectTransform FxHolder;
    [SerializeField] Image CircleImg;
    [SerializeField] Text txtProgress;

    [SerializeField] [Range(0, 1)] float progress = 0f;

    public static CircleTransition instance;
    public GameObject loadingScreen;

    private void Awake() {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.menu, LoadSceneMode.Additive);
    }

    void Update()
    {
        CircleImg.fillAmount = progress;
        txtProgress.text = Mathf.Floor(progress * 100).ToString();
        FxHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -progress * 360));
    }

    public void LoadGame() {
        loadingScreen.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.menu);
        SceneManager.LoadSceneAsync((int)SceneIndexes.listofworlds, LoadSceneMode.Additive);
    }
}
