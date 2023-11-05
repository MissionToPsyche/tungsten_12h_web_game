using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessPlantSlider : MonoBehaviour
{
    float progress = 0;
    public Slider slider;

    public void UpdateProgress()
    {
        progress = progress + 1;
        slider.value = progress;
    }
}
