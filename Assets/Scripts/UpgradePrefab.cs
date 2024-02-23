using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePrefab : MonoBehaviour
{
    [SerializeField] GameObject varibleObject;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] Button buttonGameObject;
    businessVariables businessVariable;
    totalMoneyScript totalMoneyObject;
    private int upgradeTime;

    private void Awake()
    {
        businessVariable = varibleObject.GetComponent<businessVariables>();
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();
        upgradeTime = 1;
    }

    public void updateMultiplier()
    {
        if(totalMoneyObject.totalMoney >= businessVariable.upgradeCost)
        {
            if(upgradeTime >= 3)
            {
                buttonGameObject.interactable = false;
            }
            businessVariable.level++;
            businessVariable.baseProfit += businessVariable.profitIncreasePerLevel;
            totalMoneyObject.totalMoney -= businessVariable.upgradeCost;
            businessVariable.upgradeCost *= businessVariable.upgradeCostScale;
            // Update the profit multiplier based on upgradeTime
            switch (upgradeTime)
            {
                case 1:
                    ButtonText.text = "Upgrade x3, This will cost: " + businessVariable.upgradeCost;
                    businessVariable.profitMultiplerUpgrade = 2; // First upgrade to x2
                    break;
                case 2:
                    ButtonText.text = "Upgrade x5, This will cost: " + businessVariable.upgradeCost;
                    businessVariable.profitMultiplerUpgrade = 3; // Second upgrade to x3
                    break;
                case 3:
                    ButtonText.text = "Maxed";
                    businessVariable.profitMultiplerUpgrade = 5; // Third upgrade to x5
                    break;
            }

            upgradeTime++;
        }
    }
}
