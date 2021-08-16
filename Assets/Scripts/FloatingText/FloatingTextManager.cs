using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{

    public GameObject damageTextPrefab;
    public string textToDisplay;
    public Transform TextPoint;
    Vector3 TextPos;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKeyDown(KeyCode.G)){
            
            
            
        }
    }
     private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Bullet"))
        {
            TextPos =  new Vector3(TextPoint.position.x,TextPoint.position.y,TextPoint.position.z);
            
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, TextPos, Quaternion.identity);
           DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        }
}
}
