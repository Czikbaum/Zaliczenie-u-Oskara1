using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class HungerBar : MonoBehaviour
{

    public int Hunger = 100;
    
    public float delay = 50f;
    float timer;


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

   


    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay) 
        {
            Hunger--;
            _hungerSlider.value = Hunger;
        }


    }
}

