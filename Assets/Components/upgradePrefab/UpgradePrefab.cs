using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography.X509Certificates;

public class UpgradePrefab : MonoBehaviour
{
    [SerializeField] GameObject varibleObject;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] Button buttonGameObject;
    [SerializeField] GameObject unlockedCanvas;        //this comes from upgradePrefab
    private upgradeButtonScript upgradeButtonScript;  //need this to get object of upgradeButton from businessPrefab and update its moneyGivenText 
    [SerializeField] GameObject updateLabel;
    [SerializeField] Image correspondingBusinessImage;
    [SerializeField] GameObject businessMultiplierLabel;
    [SerializeField] GameObject businessDescriptonLabel;
    [SerializeField] String description1;
    [SerializeField] String description2;
    [SerializeField] String description3;
    [SerializeField] String updateName1;
    [SerializeField] String updateName2;
    [SerializeField] String updateName3;
    public float costUp1;
    public float costUp2;
    public float costUp3;
    [SerializeField] Animator openManagerPanelAnimator;
    businessVariables businessVariable;
    totalMoneyScript totalMoneyObject;
    public int upgradeTime = 1;
    public bool firstTime = true;

    private void Awake()
    {
        businessVariable = varibleObject.GetComponent<businessVariables>();
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();
        upgradeButtonScript = unlockedCanvas.transform.Find("Image/upgradeButton").GetComponent<upgradeButtonScript>();


        DisplayClassifiedInfo();

    }
    private void DisplayClassifiedInfo()
    {
        ButtonText.text = "Upgrade Cost: Classified";
        updateLabel.GetComponent<TextMeshProUGUI>().text = "Classified Upgrades";
        businessMultiplierLabel.GetComponent<TextMeshProUGUI>().text = "Classified Business Profits";
        businessDescriptonLabel.GetComponent<TextMeshProUGUI>().text = "Unlocked more businesses to view their upgrades";
        correspondingBusinessImage.color = Color.black;
    }
    //when corresponding business is unlocked, it calls this function to display information (default awakes as classified)
    public void DisplayUpgrades()
    {
        ButtonText.text = "Upgrade Cost: " + costUp1;
        updateLabel.GetComponent<TextMeshProUGUI>().text = updateName1;
        businessMultiplierLabel.GetComponent<TextMeshProUGUI>().text = businessVariable.businessName + " Profit x2";
        businessDescriptonLabel.GetComponent<TextMeshProUGUI>().text = description1;
        correspondingBusinessImage.color = Color.white;
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
                ButtonText.text = "Upgrade Cost: " + costUp2;
                businessVariable.profitMultiplerUpgrade *= 2; // First upgrade to x2
                updateLabel.GetComponent<TextMeshProUGUI>().text = updateName2;
                businessMultiplierLabel.GetComponent<TextMeshProUGUI>().text = businessVariable.businessName + " Profit x3";
                businessDescriptonLabel.GetComponent<TextMeshProUGUI>().text = description2;
                upgradeButtonScript.updateMoneyGivenText();
                break;
            case 2:
                totalMoneyObject.totalMoney -= costUp2;
                ButtonText.text = "Upgrade Cost: " + costUp3;
                businessVariable.profitMultiplerUpgrade *= 3; // Second upgrade to x3
                updateLabel.GetComponent<TextMeshProUGUI>().text = updateName3;
                businessMultiplierLabel.GetComponent<TextMeshProUGUI>().text = businessVariable.businessName + " Profit x5";
                businessDescriptonLabel.GetComponent<TextMeshProUGUI>().text = description3;
                upgradeButtonScript.updateMoneyGivenText();
                break;
            case 3:
                totalMoneyObject.totalMoney -= costUp3;
                ButtonText.text = "MAXED";
                businessVariable.profitMultiplerUpgrade *= 5; // Third upgrade to x5
                updateLabel.GetComponent<TextMeshProUGUI>().text = "Fully Upgraded";
                businessMultiplierLabel.GetComponent<TextMeshProUGUI>().text = "Profit Multiplier: is MAXED at x30";
                businessDescriptonLabel.GetComponent<TextMeshProUGUI>().text = "This business has been fully upgraded";
                upgradeButtonScript.updateMoneyGivenText();
                break;
        }

        upgradeTime++;
    }

    void Update()
    {
        
        if (unlockedCanvas.activeSelf)      //if corresponding business is active
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
