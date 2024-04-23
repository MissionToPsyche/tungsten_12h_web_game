using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;        //text (tmp) NOT LEGACY



public class upgradeButtonScript : MonoBehaviour
{
    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;


    [SerializeField] Button upgradeButton;
    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI moneyGivenText;
    [SerializeField] TextMeshProUGUI countdownText;



    totalMoneyScript totalMoneyObject;


    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }

    public void upgradeBusinessOnClick()
    {
        //Increase level and update text
        businessVariables.level++;
        levelText.text = businessVariables.level.ToString();

        milestoneUpgrade(); //check if we hit a milestone to reduce the businesses time by half


        //increase profit of business
        businessVariables.baseProfit += businessVariables.profitIncreasePerLevel;


        //Update total money by subtracting upgrade cost (rounded after calculation)

        totalMoneyObject.totalMoney -= businessVariables.upgradeCost;   //SUBTRACT MONEY BEFORE YOU MODIFY UPGRADE COST BELOW     
        totalMoneyObject.totalMoney = (float)Math.Floor(totalMoneyObject.totalMoney * 100) / 100;
        //this above simply rounds the value we got to 2 decimal places


        //Update upgrade cost (rounded)
        businessVariables.upgradeCost *= businessVariables.upgradeCostScale;            //this increased the upgradeCost
        businessVariables.upgradeCost = (float)Math.Floor(businessVariables.upgradeCost * 100) / 100;  //this simply rounds the value we got to 2 decimal places

        updateUpgradeCostText();
        updateMoneyGivenText();

    }
    public void updateUpgradeCostText()
    {
        var (formattedValue, numericalPrefix) = totalMoneyObject.FormatMoney(businessVariables.upgradeCost); //format money before displaying
        upgradeCostText.text = formattedValue + " " + numericalPrefix + "$"; //update upgrade cost text to new cost
    }

    public void updateMoneyGivenText() 
    {
        var (formattedValue, numericalPrefix) = totalMoneyObject.FormatMoney(businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade); //format money before displaying
        moneyGivenText.text = "$" + formattedValue + " " + numericalPrefix;
    }

    public void milestoneUpgrade()
    {
        //if we hit any of these milestones we reduce the half by half effectively doubling that business profits
        if ((businessVariables.level == 25) ||
            (businessVariables.level == 50) ||
            (businessVariables.level == 75) ||
            (businessVariables.level == 100) ||
            (businessVariables.level == 200) ||
            (businessVariables.level == 300) ||
            (businessVariables.level == 400) ||
            (businessVariables.level == 500)
            )
        {
            businessVariables.secondsToFinish /= 2;
            int totalSeconds = Mathf.FloorToInt(businessVariables.secondsToFinish);
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            countdownText.text = formattedTime;
        }
    }


    private void Update()
    {
        if (businessVariables.upgradeCost <= totalMoneyObject.totalMoney)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }
}
