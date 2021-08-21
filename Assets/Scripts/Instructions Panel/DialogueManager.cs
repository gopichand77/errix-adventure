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

    // public Button canvasButton;
    // public Button playDialogue2Button;
    // public Button playDialogue3Button;
    [HideInInspector]
    #region public Bool
    private bool Dialog1, Dialog2, Dialog3, Dialog4, Dialog5;
    private bool Dialog1_entered, Dialog2_entered, Dialog3_entered, Dialog4_entered, Dialog5_entered;
    private bool Dialog1Board, Dialog2Board, Dialog3Board, Dialog4Board, Dialog5Board;
    #endregion
    public GameObject Canvas;
    public GameObject Audio;
    #region Text Variables
    public string[] Dialog1_sign, Dialog2_sign, Dialog3_sign, Dialog4_Sign, Dialog5_sign;

    #endregion
    private DialogueVertexAnimator dialogueVertexAnimator;
    void Awake()
    {
        dialogueVertexAnimator = new DialogueVertexAnimator(textBox, audioSourceGroup);
    }
    private void Start()
    {
        Dialog1_entered = false;
        Dialog2_entered = false;
        Dialog3_entered = false;
        Dialog4_entered = false;
        Dialog5_entered = false;
        index = 0;


        Canvas.SetActive(false);
        Audio.SetActive(false);

    }
    #region  Update 
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
        #region  Mouse Input

        // if ((Input.GetMouseButtonDown(0) && Dialog1Board ))
        // {
        //     if (index < Dialog1_sign.Length - 1)
        //     {
        //         index++;
        //         textBox.text = string.Empty;
        //         PlayDialog1();
        //     }
        //     else
        //     {
        //         movementScript.moveSpeed = 7f;
        //     movementScript.jumpForce  = 7f;
        //                         Canvas.SetActive(false);
        //         Audio.SetActive(false);


        //     }


        // }
        // if (Input.GetMouseButtonDown(0) && Dialog2Board)
        // {
        //     if (index < Dialog2_sign.Length - 1)
        //     {
        //         index++;
        //         textBox.text = string.Empty;
        //         PlayDialog2();
        //     }
        //     else
        //     {
        //         movementScript.moveSpeed = 7f;
        //     movementScript.jumpForce  = 7f;
        //                         Canvas.SetActive(false);
        //         Audio.SetActive(false);


        //     }


        // }
        // if (Input.GetMouseButtonDown(0) && Dialog3Board)
        // {
        //     if (index < Dialog3_sign.Length - 1)
        //     {
        //         index++;
        //         textBox.text = string.Empty;
        //         PlayeDialog3Sign();
        //     }
        //     else
        //     {
        //         movementScript.moveSpeed = 7f;
        //     movementScript.jumpForce  = 7f;
        //                         Canvas.SetActive(false);
        //         Audio.SetActive(false);


        //     }


        // }
        //  if (Input.GetMouseButtonDown(0) && Dialog4Board)
        // {
        //     if (index < Dialog4_Sign.Length - 1)
        //     {
        //         index++;
        //         textBox.text = string.Empty;
        //         PlayTrapDialog();
        //     }
        //     else
        //     {
        //         movementScript.moveSpeed = 7f;
        //     movementScript.jumpForce  = 7f;
        //         Canvas.SetActive(false);
        //         Audio.SetActive(false);


        //     }


        // }

        // if (Input.GetMouseButtonDown(0) && Dialog5Board)
        // {
        //     if (index < Dialog5_sign.Length - 1)
        //     {
        //         index++;
        //         textBox.text = string.Empty;
        //         PlayDialog5();
        //     }
        //     else
        //     {
        //         movementScript.moveSpeed = 7f;
        //     movementScript.jumpForce  = 7f;
        //         Canvas.SetActive(false);
        //         Audio.SetActive(false);


        //     }


        // }
        #endregion
    }
    #endregion
    #region  Button Input
    public void ButtonClick()
    {
        if (Dialog1Board)
        {
            if (index < Dialog1_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog1();
            }
            else
            {
                movementScript.moveSpeed = 7f;
                movementScript.jumpForce = 7f;
                Canvas.SetActive(false);
                Audio.SetActive(false);
            }

        }
        if (Dialog2Board)
        {
            if (index < Dialog2_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog2();
            }
            else
            {
                movementScript.moveSpeed = 7f;
                movementScript.jumpForce = 7f;
                Canvas.SetActive(false);
                Audio.SetActive(false);
            }
        }
        if (Dialog3Board)
        {
            if (index < Dialog3_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayeDialog3Sign();
            }
            else
            {
                movementScript.moveSpeed = 7f;
                movementScript.jumpForce = 7f;
                Canvas.SetActive(false);
                Audio.SetActive(false);
            }
        }
        if (Dialog4Board)
        {
            if (index < Dialog4_Sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayTrapDialog();
            }
            else
            {
                movementScript.moveSpeed = 7f;
                movementScript.jumpForce = 7f;
                Canvas.SetActive(false);
                Audio.SetActive(false);
            }
        }
        if (Dialog5Board)
        {
            if (index < Dialog5_sign.Length - 1)
            {
                index++;
                textBox.text = string.Empty;
                PlayDialog5();
            }
            else
            {
                movementScript.moveSpeed = 7f;
                movementScript.jumpForce = 7f;
                Canvas.SetActive(false);
                Audio.SetActive(false);
            }
        }
    }
    #endregion

    #region  Ontrigger
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name.Equals("Dialog1 signboard") && !Dialog1_entered)
        {
            index = 0;
            Dialog1_entered = true;

            movementScript.moveSpeed = 0f;
            movementScript.jumpForce = 0f;
            Dialog1 = true;
            Canvas.SetActive(true);
            Audio.SetActive(true);

        }
        if (trig.gameObject.name.Equals("Dialog2 signboard") && !Dialog2_entered)
        {
            index = 0;
            Dialog2 = true;
            Dialog2_entered = true;
            movementScript.moveSpeed = 0f;
            movementScript.jumpForce = 0f;

            Canvas.SetActive(true);
            Audio.SetActive(true);
        }
        if (trig.gameObject.name.Equals("Dialog3 signboard") && !Dialog3_entered)
        {
            index = 0;
            Dialog3 = true;
            Dialog3_entered = true;
            movementScript.moveSpeed = 0f;
            movementScript.jumpForce = 0f;
            Canvas.SetActive(true);
            Audio.SetActive(true);
        }
        if (trig.gameObject.name.Equals("Dialog4 signboard") && !Dialog4_entered)
        {
            index = 0;
            Dialog4 = true;
            Dialog4_entered = true;
            movementScript.moveSpeed = 0f;
            movementScript.jumpForce = 0f;

            Canvas.SetActive(true);
            Audio.SetActive(true);
        }

        if (trig.gameObject.name.Equals("Dialog5 signboard") && !Dialog5_entered)
        {
            index = 0;
            Dialog5 = true;
            Dialog5_entered = true;
            movementScript.moveSpeed = 0f;
            movementScript.jumpForce = 0f;

            Canvas.SetActive(true);
            Audio.SetActive(true);
        }

    }
    #endregion
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
