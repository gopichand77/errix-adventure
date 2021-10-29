using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopList : MonoBehaviour
{
    [Serializable]
    public struct ShopMenu
    {
        public string Name;
        public string Description;
        public Sprite Img;
    }

    [SerializeField] ShopMenu[] shoplist;
    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g; //to keep tack of new created items
        int n = shoplist.Length;
        for (int i = 0; i < n; i++)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = shoplist[i].Img;
            g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = shoplist[i].Name;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shoplist[i].Description;

        }
        Destroy(buttonTemplate);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
