using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // animator.SetFloat("horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
        // animator.SetFloat("vertical", Mathf.Abs(Input.GetAxis("Vertical")));
        animator.SetFloat("horizontal", Mathf.Abs(SimpleInput.GetAxis("Horizontal")));
        animator.SetFloat("vertical", Mathf.Abs(SimpleInput.GetAxis("Vertical")));
    }
}
