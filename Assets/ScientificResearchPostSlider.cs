using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScientificResearchPostSlider : MonoBehaviour
{
    float progress = 0;
    public Slider slider;

    public void UpdateProgress()
    {
        progress = progress + 1;
        slider.value = progress;
    }
}
