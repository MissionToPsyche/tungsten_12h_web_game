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

    totalMoneyScript totalMoneyScript;

    bool coroutineRunning = false;

    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }


    public void activateButtonHandler()
    {
        activateButton.interactable = false;        //button will UNCLICKABLE since its has started loading bar
        StartCoroutine(MyCoroutine());              //start coroutine
    }


   
    public void startInfiniteCoroutine()   //this button is reserved for the manager to forever run the business
    {
        StartCoroutine(infiniteCoroutine());
    }

    public IEnumerator infiniteCoroutine()
    {
        while (true){
            activateButton.interactable = false;


            //this solves the case where if user activated coroutine, we need to wait for that instance to finish
            while (coroutineRunning)
            {
                yield return null; //do nothing 
            }


            yield return StartCoroutine(MyCoroutine()); //run the coroutine that loads the bar but wait until it finishes
        }
    }

    IEnumerator MyCoroutine()
    {
        coroutineRunning = true; //mutex to immedietely lock loading bar 
        activateButton.interactable = false;


        float elapsedTime = 0f;

        while (elapsedTime < businessVariables.secondsToFinish)
        {
            // Interpolate the value from 0 to 1 based on the elapsed time
            float fillValue = Mathf.Lerp(0f, 1f, elapsedTime / businessVariables.secondsToFinish);

            // Set the loading bar value
            loadingBar.value = fillValue;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            countdownText.text = Mathf.Floor(businessVariables.secondsToFinish - elapsedTime).ToString() + "s";

            // Wait for the next frame
            yield return null;
        }

        countdownText.text = Mathf.Ceil(businessVariables.secondsToFinish).ToString() + "s";


        loadingBar.value = 0f;                  //reset the loading bar
        activateButton.interactable = true;     //make button clickable again


        //need to update total money object
        totalMoneyScript.totalMoney += businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade;

        coroutineRunning = false; // release mutex

        yield break;                            // End the coroutine
    }


}
