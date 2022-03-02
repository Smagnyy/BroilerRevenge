using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBars : MonoBehaviour
{
    public Slider healthBar;
    public Slider timerBar;
   
    public void SetMaxValue(Slider bar, float value)
    {
        bar.maxValue = value;
        bar.value = value;
    }

    public void SetValue(Slider bar, float value)
    {
        bar.value = value;
    }
}
