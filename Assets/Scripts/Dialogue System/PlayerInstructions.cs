using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerInstructions : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Sprite Right;
    public Sprite Left;
    public Sprite Jump;
    public Sprite Attack;
    public GameObject Image;
    public GameObject Dialog;
    public Button Done;
    private int Iindex;

    private int index;
    // Start is called before the first frame update
    public void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue(); 
        Done.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index]) 
            {
                NextLine();
            } 
            else {
                 StopAllCoroutines();
                textComponent.text = lines[index];
            }
            if(Input.GetMouseButtonDown(0))
        {
            index++ ;
        }
        //  if(index > 0 && index < 2 && Input.GetMouseButtonDown(0))
        //  {
        // Image.gameObject.GetComponentInChildren<Image> ().sprite = Right;
        // }
        if(index > 1 && index < 3 && Input.GetMouseButtonDown(0))
        {
        Image.gameObject.GetComponentInChildren<Image> ().sprite = Right;
          }
        if(index > 2 && index < 4&& Input.GetMouseButtonDown(0))
        {
        Image.gameObject.GetComponentInChildren<Image> ().sprite = Left;
           
        }
        if(index > 3 && index <5 && Input.GetMouseButtonDown(0))
        {
        Image.gameObject.GetComponentInChildren<Image> ().sprite = Attack;
         Done.gameObject.SetActive(true);
            
        }
        if(index > 4) 
        {
           // gameObject.SetActive(false);
            Dialog.gameObject.SetActive(false);
        }
      
       
        }
    }
    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(Input.GetMouseButtonDown(0))
        {
        if (index < lines.Length - 1)
         {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else 
        {
           // gameObject.SetActive(false);
            Dialog.gameObject.SetActive(false);
        }
        }
    } 
    public void DoneButton()
    {
       Destroy(Dialog.gameObject);


    }
}
