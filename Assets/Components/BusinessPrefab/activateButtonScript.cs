using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class activateButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
 [SerializeField] TextMeshProUGUI moneyGivenText;
    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;


    [SerializeField] Button activateButton;
    [SerializeField] Slider loadingBar;

    totalMoneyScript totalMoneyObject;

    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }


    public void activateButtonHandler()
    {
        activateButton.interactable = false;        //button will UNCLICKABLE since its has started loading bar
        StartCoroutine(MyCoroutine());              //start coroutine
    }

    IEnumerator MyCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < businessVariables.secondsToFinish)
        {
            // Interpolate the value from 0 to 1 based on the elapsed time
            float fillValue = Mathf.Lerp(0f, 1f, elapsedTime / businessVariables.secondsToFinish);

            // Set the loading bar value
            loadingBar.value = fillValue;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            countdownText.text = Mathf.Ceil(businessVariables.secondsToFinish - elapsedTime).ToString() + "s";

        moneyGivenText.text = "$" + businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade;



            // Wait for the next frame
            yield return null;
        }

        countdownText.text = Mathf.Ceil(businessVariables.secondsToFinish).ToString() + "s";

//loadingBar.ForeColor

        loadingBar.value = 0f;                  //reset the loading bar
        activateButton.interactable = true;     //make button clickable again


        //need to update total money object
        totalMoneyObject.totalMoney += businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade;

        yield break;                            // End the coroutine
    }


}
