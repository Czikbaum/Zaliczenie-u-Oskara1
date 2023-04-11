using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotrzebyUI : MonoBehaviour
{
    [SerializeField] Slider statusSlider;
   
    

    public void SetStatus(float f)
    {
        f = Mathf.Clamp(f, 0f, 100f);
        statusSlider.value = f;
    }
}
