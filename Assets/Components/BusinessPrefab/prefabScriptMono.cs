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



    //public GameObject myBusinessPrefabObject;  //no need to make object since its attached to prefab      

    public float secondsToFinish = 1.00f;     //variable dependent on business
    public float baseProfit = 1.00f;


    public float upgradeCost = 1.00f; //cost to upgrade (should be modifed after every level)
    public float upgradeCostScale = 1.07f; //(increase 1/5 each level) //how much the cost of upgrade should increase per level
    public float profitIncreasePerLevel = 1.00f;           //each level will increase profit of business by this amount (linear)
                                                                                                                                                                                                                                                                                                                                    
    public int level = 1;                           //base level is one


    public float profitMultiplerUpgrade = 1.00f; //in future when we add buttons to increase cost of each business with milestone this will get changed


    //COMPONENTS

    //canvas
    [SerializeField] private GameObject canvas;

    Button upgradeButton;
    Button activateButton;

    Slider loadingBar;

    TextMeshProUGUI levelText;
    TextMeshProUGUI upgradeCostText;


    totalMoneyScript totalMoneyObjectScript;

    // Start is called before the first frame update
    void Start()
    {
        //these components WITHIN HIERARCHY
        //canvas = transform.Find("Canvas");      //reference CANVAS OBJECT


        activateButton = transform.Find("Canvas/activateButton").GetComponent<Button>();      //reference ACTIVATE BUTTON OBJECT
        upgradeButton = transform.Find("Canvas/upgradeButton").GetComponent<Button>();        //reference UPGRADE BUTTON OBJECT
        loadingBar = transform.Find("Canvas/loadingBar").GetComponent<Slider>();              //reference LOADING BAR OBJECT
        levelText = transform.Find("Canvas/level").GetComponent<TextMeshProUGUI>();           //reference LEVEL TEXT OBJECT
        upgradeCostText = transform.Find("Canvas/upgradeButton/upgradeCostTextInButton").GetComponent<TextMeshProUGUI>();           //reference COST TO UPGRADE TEXT OBJECT


        //objects OUTSIDE HIERARCHY
        totalMoneyObjectScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject




        //update text on based on variables
        upgradeCostText.text = upgradeCost.ToString() + "$";
        levelText.text = level.ToString();

        //create button handlers
        activateButton.onClick.AddListener(activateButtonHandler);     //activateButton listener (can initiate in global)
        upgradeButton.onClick.AddListener(upgradeButtonHandler);     //activateButton listener (can initiate in global)

        //set loading bar inactive
        canvas.SetActive(false);

    }

    //"upgradeButton" Handler
    void upgradeButtonHandler()
    {
        //increase level and update text
        level++;
        levelText.text = level.ToString();    


        //increase profit of business
        baseProfit += profitIncreasePerLevel;       //increase profit of business 


        //update total money by subtracting upgrade cost (rounded after calculation)
        totalMoneyObjectScript.totalMoney -= upgradeCost;   //SUBTRACT MONEY BEFORE YOU MODIFY UPGRADE COST BELOW     
        totalMoneyObjectScript.totalMoney = (float)Math.Floor(totalMoneyObjectScript.totalMoney * 100) / 100;  //this simply rounds the value we got to 2 decimal places


        //update upgrade cost (rounded)
        upgradeCost *= upgradeCostScale;            //this increased the upgradeCost
        upgradeCost = (float)Math.Floor(upgradeCost * 100) / 100;  //this simply rounds the value we got to 2 decimal places

        upgradeCostText.text = upgradeCost.ToString() + "$"; //update upgrade cost text to new cost

    }

    //"activateButton" Handler
    void activateButtonHandler()
    {
        activateButton.interactable = false;              //button will UNCLICKABLE since its has started loading bar
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
        totalMoneyObjectScript.totalMoney += baseProfit;

        yield break;                            // End the coroutine
    }

    // Update is called once per frame
    void Update()
    {
        //if upgrade cost is less than total money make upgrade button interactable
        if (upgradeCost <= totalMoneyObjectScript.totalMoney)
        {
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
        }
    }
}
