using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullHealth : MonoBehaviour
{
    // public Transform image;
    public Image bullHealthbar;
    float health, maxHealth = 100f;
    public Bull bullScript;
    float lerpSpeed;
    public Vector3 offset;

    private void Start()
    {
        health = maxHealth;
        bullScript.bullHealth = health;
    }

    private void FixedUpdate()
    {
        HealthBarFiller();
        ColorChanger();
        lerpSpeed = 3f * Time.deltaTime;
        bullHealthbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    void HealthBarFiller()
    {
        health = bullScript.bullHealth;
        // BullHealthbar.fillAmount = health/maxHealth;
        bullHealthbar.fillAmount = Mathf.Lerp(bullHealthbar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        bullHealthbar.color = healthColor;
    }
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
