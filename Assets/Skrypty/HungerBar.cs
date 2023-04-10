using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{

    public int Hunger = 100; 

    Slider _hungerSlider;

    private void Start()
    {
        _hungerSlider = GetComponent<Slider>();
    }


    public void SetMaxHunger(int maxHunger)
    {
        _hungerSlider.maxValue = maxHunger;
        _hungerSlider.value = maxHunger;
    }

    public void SetHunger(int hunger)
    {
        _hungerSlider.value = hunger;
    }


    public void Update()
    {
        
    }
}

