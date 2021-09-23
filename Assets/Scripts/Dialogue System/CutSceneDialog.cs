using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CutSceneDialog : MonoBehaviour
{   
    public TMP_Text textBox;
    public AudioClip typingClip;
    private DialogueVertexAnimator dialogueVertexAnimator;
    public AudioSourceGroup audioSourceGroup;
    public string[] Dialog1_sign, Dialog2_sign,Dialog3_sign,Dialog4_sign;
    private int index;
    public int lineIndex;
    public float timGap;
    public bool Dialog1 = true;
    public bool Dialog2 = true;
    public bool Dialog3 = true;
    public bool Dialog4 = true;
    void Awake()
    {
        
        index = 0;
        lineIndex = 0;
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
    }
    
    public void Dialog_Text1()
    {
        
        if(Dialog1)
        {
            index =  lineIndex;
            PlayDialog1();
            textBox.text = string.Empty;
            if(index < Dialog1_sign.Length -1)
            {
                 Dialog1 = false;
                StartCoroutine(Time());
                
                
            }
            else
            {
                Dialog1 = true;
                lineIndex = 0;
                // index = 0;
               
            }
            
        } 


    }
    public void Dialog_Text2()
    {
        
        if(Dialog2)
        {
            
            index =  lineIndex;
            PlayDialog2();
            textBox.text = string.Empty;
            if(index < Dialog2_sign.Length - 1)
            {
                Dialog2 = false;
                StartCoroutine(Time());
                
                
            }
            else
            {
                Dialog2 = true;
                lineIndex = 0;
            }
            
        } 


    }
    public void Dialog_Text3()
    {
        if(Dialog3)
        {
            textBox.text = string.Empty;
            index =  lineIndex;
            PlayDialog3();
            if(index < Dialog3_sign.Length - 1)
            {
                Dialog3 = false;
                StartCoroutine(Time());
                
            }
            else
            {
                Dialog3 = true;
                lineIndex = 0;
            }
        }
    }
    public void Dialog_Text4()
    {
        if(Dialog4)
        {
            textBox.text = string.Empty;
            index =  lineIndex;
            PlayDialog4();
            if(index < Dialog4_sign.Length - 1)
            {
                Dialog4 = false;
                StartCoroutine(Time());
                
            }
            else
            {
                Dialog4 = true;
                lineIndex = 0;
            }
        }
    }

     

    private IEnumerator Time()
    {
        
     
        // textBox.text = string.Empty;
        yield return new WaitForSeconds(timGap);
        lineIndex += 1;
        textBox.text = string.Empty;
        if(!Dialog1)
        {
            Dialog1 = true;
            Dialog_Text1();
            
            textBox.text = string.Empty;
        }
        if(!Dialog2)
        {
            Dialog2 =  true;
            Dialog_Text2();
            textBox.text = string.Empty;
        }
        if(!Dialog3)
        {
            Dialog3 = true;
            Dialog_Text3();
            textBox.text = string.Empty;
        }
        if(!Dialog4)
        {
            Dialog4 = true;
            Dialog_Text4();
            textBox.text = string.Empty;
        }

         Debug.Log("Working");
         
          
       
    }
    
    private void PlayDialog1()
    {
        PlayDialogue(Dialog1_sign[index]);
    }

    private void PlayDialog2()
    {
        PlayDialogue(Dialog2_sign[index]);
    }
     private void PlayDialog3()
    {
        PlayDialogue(Dialog3_sign[index]);
    }
    private void PlayDialog4()
    {
        PlayDialogue(Dialog4_sign[index]);
    }
    private Coroutine typeRoutine = null;
    void PlayDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
