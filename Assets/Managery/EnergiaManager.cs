using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaManager : MonoBehaviour
{

    public Slider timerSlider;
    public float EnergiaTime;
    

    private bool stopTimer;


    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = EnergiaTime;
        timerSlider.value = EnergiaTime;
    }

   
    // Update is called once per frame
    void Update()
    {
        float time = EnergiaTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);



        if (time <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {

            timerSlider.value = time;
        }

        
    }

   
}