using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class astroSliderController : MonoBehaviour
{
    int progress = 0;
    public Slider slider;

    public void UpdateProgress()
    {
        progress = progress + 2;
        slider.value = progress;
    }
}
