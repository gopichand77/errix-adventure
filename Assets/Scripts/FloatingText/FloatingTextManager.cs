using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{

    public GameObject damageTextPrefab, character;
    public string textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, character.transform);
            DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        }
    }
}
