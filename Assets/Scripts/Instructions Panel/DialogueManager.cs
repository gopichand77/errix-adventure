using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;
    private int index;
    [SerializeField]
    PlayerMovement movementScript;

    // public Button playDialogue1Button;
    // public Button playDialogue2Button;
    // public Button playDialogue3Button;
    [HideInInspector]
    #region public Bool
    private bool Dialog1;
    private bool Dialog2;
    private bool Dialog3;
    private bool Dialog4;
    private bool Dialog5;
    private bool Dialog1_entered;
    private bool Dialog2_entered;
    private bool Dialog3_entered;
    private bool Dialog4_entered;
    private bool Dialog5_entered;

    private bool Dialog1Board;
    private bool Dialog2Board;
    private bool Dialog3Board;
    private bool Dialog4Board;
    private bool Dialog5Board;
    #endregion

    public GameObject Canvas;
    public GameObject Audio;
    
    [TextArea]
    public string[] Dialog1_sign;
    public string[] Dialog2_sign;
    public string[] Dialog3_sign;
    public string[] Dialog4_Sign;
    public string[] Dialog5_sign;

    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake()
    {

        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);

    }
    private void Start()
    {
        index = 0;


        Canvas.SetActive(false);
        Audio.SetActive(false);

    }
    private void Update()
    {
        if (Dialog1)
        {

            Dialog2Board = false;
            Dialog3Board = false;
            Dialog4Board = false;
            Dialog5Board = false;

            Invoke("False", 0.0001f);
            PlayDialog1();
            Dialog1Board = true;
        }

        if (Dialog2)
        {
            Invoke("False", 0.0001f);

            Dialog2Board = true;
            Dialog1Board = false;

            Dialog3Board = false;
            Dialog4Board = false;
            Dialog5Board = false;
            PlayDialog2();
        }
        if (Dialog4)
        {
            Dialog1Board = false;
            Dialog2Board = false;
            Dialog3Board = false;

            Dialog5Board = false;
            Dialog4Board = true;
            Invoke("False", 0.0001f);


            PlayTrapDialog();
        }
        if (Dialog5)
        {
            Dialog1Board = false;
            Dialog2Board = false;
            Dialog3Board = false;
            Dialog4Board = false;

            Dialog5Board = true;
            Invoke("False", 0.0001f);


            PlayDialog5();
        }
        if (Dialog3)
        {
            Dialog1Board = false;
            Dialog2Board = false;

            Dialog4Board = false;
            Dialog5Board = false;
            Dialog3Board = true;
            Invoke("False", 0.0001f);


            PlayeDialog3Sign();
        }
        if (Input.GetMouseButtonDown(0) && Dialog1Board)
        {
            if (index < Dialog1_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog1();
            }
            else
            {
                Canvas.SetActive(false);
                Audio.SetActive(false);


            }


        }
        if (Input.GetMouseButtonDown(0) && Dialog2Board)
        {
            if (index < Dialog2_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog2();
            }
            else
            {
                Canvas.SetActive(false);
                Audio.SetActive(false);


            }


        }
        if (Input.GetMouseButtonDown(0) && Dialog3Board)
        {
            if (index < Dialog3_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayeDialog3Sign();
            }
            else
            {
                Canvas.SetActive(false);
                Audio.SetActive(false);


            }


        }
        if (Input.GetMouseButtonDown(0) && Dialog5Board)
        {
            if (index < Dialog5_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog5();
            }
            else
            {
                Canvas.SetActive(false);
                Audio.SetActive(false);


            }


        }
        if (Input.GetMouseButtonDown(0) && Dialog4Board)
        {
            if (index < Dialog4_Sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayTrapDialog();
            }
            else
            {
                Canvas.SetActive(false);
                Audio.SetActive(false);


            }


        }


    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name.Equals("Dialog1 signboard"))
        {

            index = 0;
            Dialog1 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);

        }
        if (trig.gameObject.name.Equals("Dialog2 signboard"))
        {
            index = 0;
            Dialog2 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);
        }
        if (trig.gameObject.name.Equals("Dialog3 signboard"))
        {
            index = 0;
            Dialog3 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);
        }
        if (trig.gameObject.name.Equals("Dialog4 signboard"))
        {
            index = 0;
            Dialog4 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);
        }
        
        if (trig.gameObject.name.Equals("Dialog5 signboard"))
        {
            index = 0;
            Dialog5 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);
        }

    }
    void False()
    {

        Dialog1 = false;
        Dialog2 = false;
        Dialog4 = false;
        Dialog3 = false;
        Dialog5 = false;


    }

    private void PlayDialog1()
    {

        PlayDialogue(Dialog1_sign[index]);
    }

    private void PlayDialog2()
    {

        PlayDialogue(Dialog2_sign[index]);
    }

    private void PlayeDialog3Sign()
    {

        PlayDialogue(Dialog3_sign[index]);
    }
    private void PlayTrapDialog()
    {

        PlayDialogue(Dialog4_Sign[index]);
    }
    private void PlayDialog5()
    {

        PlayDialogue(Dialog5_sign[index]);
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
