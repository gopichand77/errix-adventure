using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public static class ButtonExtension
{
	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener (delegate() {
			OnClick (param);
		});
	}
}


public class ShopList : MonoBehaviour
{
    [Serializable]
    public struct ShopMenu
    {
        public string Name;
        public string Description;
        public Sprite Img;
        public Button button;
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
            // g.transform.GetChild(3).GetComponent<Button>() = shoplist[i].button;
            g.GetComponent <Button> ().AddEventListener (i, ItemClicked);
            

        }
        Destroy(buttonTemplate);

        void ItemClicked (int itemIndex)
	{
		Debug.Log ("------------item " + itemIndex + " clicked---------------");
		Debug.Log ("name " + shoplist [itemIndex].Name);
		Debug.Log ("desc " + shoplist [itemIndex].Description);
	}

    }

    // Update is called once per frame
    void Update()
    {

    }
}
