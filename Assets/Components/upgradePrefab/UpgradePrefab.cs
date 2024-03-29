using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradePrefab : MonoBehaviour
{
    [SerializeField] GameObject varibleObject;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] Button buttonGameObject;
    [SerializeField] GameObject unlockedCanvas;
    [SerializeField] float costUp1;
    [SerializeField] float costUp2;
    [SerializeField] float costUp3;
    businessVariables businessVariable;
    totalMoneyScript totalMoneyObject;
    private int upgradeTime;
    private bool upgradeUnlocked = false;
    private void Awake()
    {
        businessVariable = varibleObject.GetComponent<businessVariables>();
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();
        upgradeTime = 1;
    }

    public void updateMultiplier()
    {
        if (upgradeTime >= 3)
        {
            buttonGameObject.interactable = false;
        }


        // Update the profit multiplier based on upgradeTime
        switch (upgradeTime)
        {
            case 1:
                totalMoneyObject.totalMoney -= costUp1;
                ButtonText.text = "Upgrade x3, This will cost: " + businessVariable.upgradeCost;
                businessVariable.profitMultiplerUpgrade *= 2; // First upgrade to x2
                break;
            case 2:
                totalMoneyObject.totalMoney -= costUp2;
                ButtonText.text = "Upgrade x5, This will cost: " + businessVariable.upgradeCost;
                businessVariable.profitMultiplerUpgrade *= 3; // Second upgrade to x3
                break;
            case 3:
                totalMoneyObject.totalMoney -= costUp3;
                ButtonText.text = "Maxed";
                businessVariable.profitMultiplerUpgrade *= 5; // Third upgrade to x5
                break;
        }

        upgradeTime++;
    }

    void Update()
    {
        if (unlockedCanvas.activeSelf)
        {
            switch (upgradeTime)
            {
                case 1:
                    buttonGameObject.interactable = totalMoneyObject.totalMoney >= costUp1;
                    break;
                case 2:
                    buttonGameObject.interactable = totalMoneyObject.totalMoney >= costUp2;
                    break;
                case 3:
                    buttonGameObject.interactable = totalMoneyObject.totalMoney >= costUp3;
                    break;
            }
        }
        else {             
            buttonGameObject.interactable = false;
        }
    }

}
