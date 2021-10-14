using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem confetti;
    public GameObject transitionPanel;
    private GameObject controlPanel;
    SingleLevel levelDone;
    private int currentStarsNum = 0;
    public int levelIndex;
    // Start is called before the first frame update
    private void Start()
    {
        animator =  gameObject.GetComponent<Animator>();
        confetti =  transform.GetChild(0).GetComponentInChildren<ParticleSystem>();
        controlPanel =  GameObject.Find("Controls Panel");
      
        
        // transitionPanel = Resources.Load("Assets/Prefabs/Player/Ul Elements/Grasslands/Grasslands Next Level Panel", typeof(GameObject)) as GameObject;
        levelDone =  FindObjectOfType<SingleLevel>();
    }
    private void Update()
    {
        // transitionPanel = Resources.Load("Grasslands Next Level Panel")as GameObject;
       
        
        
        
        //  if(Input.GetKeyDown(KeyCode.J))
        // {
        //     GameObject pnel = Instantiate<GameObject>(transitionPanel,new Vector3 (12.59998f, 0, 0), Quaternion.identity);
        //   var rect = pnel.GetComponent<RectTransform>();
        //    rect.SetPadding(left: 12.59998f, top: 0, right: -12.59998f, bottom: 0);
        // //   GameObject panel = Instantiate<GameObject>(transitionPanel,rect, Quaternion.identity);

        //     pnel.transform.SetParent(controlPanel.transform.parent);
            
        //    pnel.gameObject.SetActive(true);
        // }
        // transitionPanel = GameObject.Find("Grasslands Next Level Panel");
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Done",true);
            // confetti.Play();
            StartCoroutine(ConfettiPlay());
            StartCoroutine(Level());
            PressStarsButton();
        }
    }
    IEnumerator Level()
    {
        yield return new WaitForSeconds(5);
        transitionPanel.gameObject.SetActive(true);
        controlPanel.SetActive(false);
        
    }

    IEnumerator ConfettiPlay(){
        confetti.Play();
        yield return new WaitForSeconds(4);
        confetti.Stop();
    }
    public void PressStarsButton()
    {
        currentStarsNum = levelDone.currentStarsNum;

        if(currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelDone.currentStarsNum);
        }
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, levelDone.currentStarsNum));

     
    }

     
     
}
    public static class Extensions
{
    public static void SetPadding(this RectTransform rect, float horizontal, float vertical) {
        rect.offsetMax = new Vector2(-horizontal, -vertical);
        rect.offsetMin = new Vector2(horizontal, vertical);
    }

    public static void SetPadding(this RectTransform rect, float left, float top, float right, float bottom)
    {
        rect.offsetMax = new Vector2(-right, -top);
        rect.offsetMin = new Vector2(left, bottom);
    }
}
