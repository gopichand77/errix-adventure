using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class IntroDialog : MonoBehaviour
{
    public TMP_Text textBox;
    public AudioClip typingClip;
    private DialogueVertexAnimator dialogueVertexAnimator;
    public AudioSourceGroup audioSourceGroup;
    public string[] Dialog1_sign, Dialog2_sign,Dialog3_sign,Dialog4_sign;
    private int index;
    public float timGap;
    public bool Dialog1 = true;
    public bool Dialog2 = true;
    public bool Dialog3 = true;
    public bool Dialog4 = true;
    void Awake()
    {
        
        index = 0;
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
    }
    
    public void Dialog_Text1()
    {
        
        if(Dialog1)
        {
            
            PlayDialog1();
            textBox.text = string.Empty;
            if(index < Dialog1_sign.Length - 1)
            {
                Dialog1 = false;
                StartCoroutine(Time());
                
            }
            else
            {
                Dialog1 = false;
            }
            
        } 


    }
    public void Dialog_Text2()
    {
        if(Dialog2)
        {
            textBox.text = string.Empty;
            PlayDialog2();
            if(index < Dialog2_sign.Length - 1)
            {
                Dialog2 = false;
                StartCoroutine(Time());
                
                
            }
            else
            {
                Dialog2 = false;
            }
            
        } 


    }
    public void Dialog_Text3()
    {
        if(Dialog3)
        {
            textBox.text = string.Empty;
            PlayDialog3();
            if(index < Dialog3_sign.Length - 1)
            {
                StartCoroutine(Time());
                Dialog3 = false;
            }
            else
            {
                Dialog3 = false;
            }
        }
    }
    public void Dialog_Text4()
    {
        if(Dialog4)
        {
            textBox.text = string.Empty;
            PlayDialog4();
            if(index < Dialog4_sign.Length - 1)
            {
                Dialog4 = false;
                StartCoroutine(Time());
                
            }
            else
            {
                Dialog4 = false;
            }
        }
    }

     

    private IEnumerator Time()
    {
        
     
        textBox.text = string.Empty;
        yield return new WaitForSeconds(timGap);
        index++;
        textBox.text = string.Empty;
        if(!Dialog1)
        {
            PlayDialog1();
            textBox.text = string.Empty;
        }
        if(!Dialog2)
        {
            PlayDialog2();
            textBox.text = string.Empty;
        }
        if(!Dialog3)
        {
            PlayDialog3();
            textBox.text = string.Empty;
        }
        if(!Dialog4)
        {
            PlayDialog4();
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
