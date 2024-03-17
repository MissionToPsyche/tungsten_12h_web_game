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


    totalMoneyScript totalMoneyObject;


    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }

    public void upgradeBusinessOnClick()
    {
        //we retrieve variables we use from object //we need to modify the variables directly so we cant simply retrive the ones we need
        //int level = businessVariables.level;
        //float baseProfit = businessVariables.baseProfit;
        //float profitIncreasePerLevel = businessVariables.profitIncreasePerLevel;
        //float upgradeCost = businessVariables.upgradeCost;
        //float upgradeCostScale = businessVariables.upgradeCostScale;

        //Increase level and update text
        businessVariables.level++;
        levelText.text = businessVariables.level.ToString();


        //increase profit of business
        businessVariables.baseProfit += businessVariables.profitIncreasePerLevel;


        //Update total money by subtracting upgrade cost (rounded after calculation)
        totalMoneyObject.totalMoney -= businessVariables.upgradeCost;   //SUBTRACT MONEY BEFORE YOU MODIFY UPGRADE COST BELOW     
        totalMoneyObject.totalMoney = (float)Math.Floor(totalMoneyObject.totalMoney * 100) / 100;
        //this above simply rounds the value we got to 2 decimal places


        //Update upgrade cost (rounded)
        businessVariables.upgradeCost *= businessVariables.upgradeCostScale;            //this increased the upgradeCost
        businessVariables.upgradeCost = (float)Math.Floor(businessVariables.upgradeCost * 100) / 100;  //this simply rounds the value we got to 2 decimal places

        upgradeCostText.text = businessVariables.upgradeCost.ToString() + "$"; //update upgrade cost text to new cost

        moneyGivenText.text = "$" + businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade;

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
