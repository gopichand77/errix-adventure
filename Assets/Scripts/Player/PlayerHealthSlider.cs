using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSlider : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float speed = 5f;

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
        slider.value = Mathf.Lerp(slider.value,health, speed);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
