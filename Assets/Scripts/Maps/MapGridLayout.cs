using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGridLayout : MonoBehaviour
{

    [Header("Grid Layout Group")]
    public GridLayoutGroup gridLayoutGroup;
    private float scr_Width, scr_Height;

    private void FixedUpdate()
    {
        scr_Height = Screen.height;
        scr_Width = Screen.width;
        Debug.Log(scr_Width + "is width");
        Debug.Log(scr_Height + "is Height");
        ChangePadding();

    }

    private void ChangePadding()
    {
        // gridLayoutGroup.cellSize = new Vector2(scr_Height / 4, scr_Height / 4);
        // gridLayoutGroup.spacing = new Vector2(scr_Height / 4, scr_Height / 4);

        //samsung fold
        if (scr_Height > 900 && scr_Width > 2600)
        {
            gridLayoutGroup.cellSize = new Vector2(180,180);
            gridLayoutGroup.spacing = new Vector2(140, 20);
        }
    }
}
