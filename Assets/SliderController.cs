using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    float fill = 0f; // how long it takes to fill the progress slider
    public Text countdownText; // countdown text for how long it takes slider to complete a fill cycle
    public Text overallMoneyText; // overall money amount text 
    private Slider slider;

    private static float overallMoney = 0f; // overall money amount actual value


    private void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void UpdateProgress(GameObject buttonObject)
    {
        string tag = gameObject.tag; // get the tag that is linked to the button

        if (buttonObject != null)
        {
            // Determine which button to activate the correct slider

            if (tag == "DrillButton")
            {
                fill = 0.35f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "AstroButton")
            {
                fill = 3f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "LabButton")
            {
                fill = 5f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "TransportButton")
            {
                fill = 7f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "OutpostButton")
            {
                fill = 9f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "ProcessButton")
            {
                fill = 11f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "StationButton")
            {
                fill = 13f;
                StartCoroutine(FillSlider(tag, fill));
            }
            else if (tag == "ResortButton")
            {
                fill = 15f;
                StartCoroutine(FillSlider(tag, fill));
            }

        }
    }
    private IEnumerator FillSlider(string buttonTag, float fillDuration)
    {
        float elapsedTime = 0f;
        float targetValue = slider.maxValue;

        while (elapsedTime < fillDuration)
        {
            // Incrementally fill the slider over time
            slider.value = Mathf.Lerp(0f, targetValue, elapsedTime / fillDuration);
            // Update the countdown text
            countdownText.text = Mathf.Ceil(fillDuration - elapsedTime).ToString();

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the slider reaches its max value
        slider.value = targetValue;

        // Increase overall money count
        IncreaseOverallMoney();

        yield return new WaitForSeconds(0f); // No delay before resetting
        slider.value = slider.minValue;  // Reset the slider value after filling

        // Reset the countdown text
        if (countdownText != null)
        {
            countdownText.text = "0";
        }

        UpdateOverallMoneyText();
    }

    private void IncreaseOverallMoney()
    {
        overallMoney += 10; // Need to update for each specific button
        UpdateOverallMoneyText();
    }

    private void UpdateOverallMoneyText()
    {
        if (overallMoneyText != null)
        {
            overallMoneyText.text = "$" + overallMoney.ToString();
        }
    }

}
