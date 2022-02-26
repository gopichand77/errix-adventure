using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart_bttn : MonoBehaviour
{
    
    public Transition trans;
    internal Button bttn;
    internal string nameLevel;
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
        trans =  FindObjectOfType<Transition>();
        bttn =  gameObject.GetComponent<Button>();
        bttn.onClick.AddListener(()=> trans.Restart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
