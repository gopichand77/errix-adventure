using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSwiper : MonoBehaviour
{
    public GameObject scrollbar;
    float scrollPos = 0;
    float [] pos;
    int posisi = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Next()
    {
        if (posisi < pos.Length - 1)
        {
            posisi += 1;
            scrollPos = pos[posisi];
        }
    }
    public void Previous()
    {
        if (posisi > 0 )
        {
            posisi -= 1;
            scrollPos = pos[posisi];
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButtonDown(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar> ().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar> ().value, pos[i], 0.15f);
                    posisi = i;
                }
            }
        }
    }
}
