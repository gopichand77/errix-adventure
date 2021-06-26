using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public Sprite Newsprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTreasure()
    {
        spriteRenderer.sprite = Newsprite;
    }
    public void OpenChest()
    {
        anim.SetBool("Open",true);
        
    }

}
