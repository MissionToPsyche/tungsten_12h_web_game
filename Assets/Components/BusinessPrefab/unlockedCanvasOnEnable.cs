using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;        //text (tmp) NOT LEGACY


public class unlockedCanvasOnEnable : MonoBehaviour
{
    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;

    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] TextMeshProUGUI levelText;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI moneyGivenText;

    totalMoneyScript totalMoneyObject;

    private void Awake()
    {
        // Assuming businessVariables script is attached to the variableObject
        businessVariables = variableObject.GetComponent<businessVariables>();
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject

    }


    //"OnEnable" is activated when a GAMEOBJECT is ".setActive(true)";
    void OnEnable()
    {
        var (formattedValue, numericalPrefix) = totalMoneyObject.FormatMoney(businessVariables.upgradeCost); //format money before displaying
        upgradeCostText.text = formattedValue + " " + numericalPrefix + "$"; //update upgrade cost text to new cost

        levelText.text = businessVariables.level.ToString();
        countdownText.text = Mathf.Ceil(businessVariables.secondsToFinish).ToString() + "s";


        (formattedValue, numericalPrefix) = totalMoneyObject.FormatMoney(businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade); //format money before displaying
        moneyGivenText.text = "$" + formattedValue + " " + numericalPrefix;
    }
}
