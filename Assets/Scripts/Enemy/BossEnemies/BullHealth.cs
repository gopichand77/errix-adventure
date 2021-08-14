using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullHealth : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //to set the max health of player
    public void SetMaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    //to the health using the slider
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


//.....|old
    // // public Transform image;
    // public Image bullHealthbar;
    // float health, maxHealth = 100f;
    // public Bull bullScript;
    // float lerpSpeed;
    // public float Yoffset;
    // public float Xoffset;
    // [SerializeField]
    // Transform bullEnemy;

    // private void Start()
    // {
    //     health = maxHealth;
    //     bullScript.bullHealth = health;
    // }

    // private void FixedUpdate()
    // {
    //     transform.position = new Vector2(bullEnemy.position.x+ Xoffset,bullEnemy.position.y + Yoffset);
    //     HealthBarFiller();
    //     ColorChanger();
    //     lerpSpeed = 3f * Time.deltaTime;
    //     // transform.position = Camera.main.WorldToScreenPoint(new Vector2(bullEnemy.position.x,bullEnemy.position.y));
    // }
    // void HealthBarFiller()
    // {
    //     health = bullScript.bullHealth;
    //     // BullHealthbar.fillAmount = health/maxHealth;
    //     bullHealthbar.fillAmount = Mathf.Lerp(bullHealthbar.fillAmount, health / maxHealth, lerpSpeed);
    // }

    // void ColorChanger()
    // {
    //     Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
    //     bullHealthbar.color = healthColor;
    // }
//old.....|^




    // public Slider slider;
    // public Color low;
    // public Color high;
    // public Vector3 offset;
    // // Update is called once per frame
    // void Update()
    // {
    //     slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position +offset);

    // }

    // public void SetHealth(float health, float maxHealth){
    //     slider.gameObject.SetActive(health< maxHealth);
    //     slider.value = health;
    //     slider.maxValue = maxHealth;

    //     slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low,high,slider.normalizedValue);
    // }
}
