using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ADDED
using UnityEngine.UI; //text, buttons, slider etc
using TMPro;        //text (tmp) NOT LEGACY

using System;   //math



public class prefabScriptMono : MonoBehaviour
{
    public float unlockCost = 0;                    //still have to click at 0 to unlock                    




    public float secondsToFinish = 1.00f;     //variable dependent on business
    public float baseProfit = 1.00f;


    public float upgradeCost = 1.00f; //cost to upgrade (should be modifed after every level)
    public float upgradeCostScale = 1.07f; //(increase 1/5 each level) //how much the cost of upgrade should increase per level
    public float profitIncreasePerLevel = 1.00f;           //each level will increase profit of business by this amount (linear)

    public int level = 1;                           //base level is one


    public float profitMultiplerUpgrade = 1.00f; //in future when we add buttons to increase cost of each business with milestone this will get changed


    //COMPONENTS
    //These objects are displayed in order to unlock the business
    [SerializeField] GameObject unlockCanvas;
    [SerializeField] Button unlockButton;
    [SerializeField] TextMeshProUGUI businessNameText;
    [SerializeField] TextMeshProUGUI unlockCostText;

    //These objects are all when the business is unlocked
    [SerializeField] GameObject unlockedCanvas;
    [SerializeField] Slider loadingBar;
    [SerializeField] Button activateButton;
    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] TextMeshProUGUI levelText;



    totalMoneyScript totalMoneyObject; //can i add objecta outside the hierarchy??

    // Start is called before the first frame update
    void Start()
    {
        //INSTEAD OF FINDING WITH CODE WE USE UNITY EDITOR TO DRAG AND DROP OBJECTS INTO THIS OBJECT
        //these components WITHIN HIERARCHY
        //canvas = transform.Find("Canvas");      //reference CANVAS OBJECT
        //activateButton = transform.Find("Canvas/activateButton").GetComponent<Button>();      //reference ACTIVATE BUTTON OBJECT
        //upgradeButton = transform.Find("Canvas/upgradeButton").GetComponent<Button>();        //reference UPGRADE BUTTON OBJECT
        //loadingBar = transform.Find("Canvas/loadingBar").GetComponent<Slider>();              //reference LOADING BAR OBJECT
        //levelText = transform.Find("Canvas/level").GetComponent<TextMeshProUGUI>();           //reference LEVEL TEXT OBJECT
        //upgradeCostText = transform.Find("Canvas/upgradeButton/upgradeCostTextInButton").GetComponent<TextMeshProUGUI>();           //reference COST TO UPGRADE TEXT OBJECT


        //objects OUTSIDE HIERARCHY
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject




        //update text on based on variables
        upgradeCostText.text = upgradeCost.ToString() + "$";
        levelText.text = level.ToString();


        //NO NEED TO CREATE BUTTON HANDLERS SINCE WE CAN ADD ON CLICK IN UNITY EDITOR
        //create button handlers
        //activateButton.onClick.AddListener(activateButtonHandler);     //activateButton listener (can initiate in global)
        //upgradeButton.onClick.AddListener(upgradeButtonHandler);     //activateButton listener (can initiate in global)

        //hide all UI elements related after the business is unlocked
        unlockedCanvas.SetActive(false);

    }

    //"upgradeButton" Handler
    void upgradeBusinessHandler()
    {
        //Increase level and update text
        level++;
        levelText.text = level.ToString();    


        //increase profit of business
        baseProfit += profitIncreasePerLevel;


        //Update total money by subtracting upgrade cost (rounded after calculation)
        totalMoneyObject.totalMoney -= upgradeCost;   //SUBTRACT MONEY BEFORE YOU MODIFY UPGRADE COST BELOW     
        totalMoneyObject.totalMoney = (float)Math.Floor(totalMoneyObject.totalMoney * 100) / 100;  
        //this above simply rounds the value we got to 2 decimal places


        //Update upgrade cost (rounded)
        upgradeCost *= upgradeCostScale;            //this increased the upgradeCost
        upgradeCost = (float)Math.Floor(upgradeCost * 100) / 100;  //this simply rounds the value we got to 2 decimal places

        upgradeCostText.text = upgradeCost.ToString() + "$"; //update upgrade cost text to new cost

    }


    //THIS BUTTON WILL START THE LOADING BAR COROUTINE
    public void activateButtonHandler()
    {
        activateButton.interactable = false;        //button will UNCLICKABLE since its has started loading bar
        StartCoroutine(MyCoroutine());              //start coroutine
    }


    IEnumerator MyCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < secondsToFinish)
        {
            // Interpolate the value from 0 to 1 based on the elapsed time
            float fillValue = Mathf.Lerp(0f, 1f, elapsedTime / secondsToFinish);

            // Set the loading bar value
            loadingBar.value = fillValue;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        loadingBar.value = 0f;                  //reset the loading bar
        activateButton.interactable = true;     //make button clickable again

        //need to update total money object
        totalMoneyObject.totalMoney += baseProfit;

        yield break;                            // End the coroutine
    }

    void Update()
    {
        //IN ORDER TO UNLOCK THE BUSINESS
        if (unlockCost <= totalMoneyObject.totalMoney)
        {
            unlockButton.interactable = false;
        } else
        {
            unlockButton.interactable |= true;
        }


        //IN ORDER TO UPGRADE
        if (upgradeCost <= totalMoneyObject.totalMoney)
        {
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
        }
    }
}
