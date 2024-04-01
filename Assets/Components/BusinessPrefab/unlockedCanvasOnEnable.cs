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
    private void Awake()
    {
        // Assuming businessVariables script is attached to the variableObject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }


    //"OnEnable" is activated when a GAMEOBJECT is ".setActive(true)";
    void OnEnable()
    {
        upgradeCostText.text = businessVariables.upgradeCost.ToString() + "$"; //update upgrade cost text to new cost
        levelText.text = businessVariables.level.ToString();

        countdownText.text = Mathf.Ceil(businessVariables.secondsToFinish).ToString() + "s";
        moneyGivenText.text = "$" + businessVariables.baseProfit * businessVariables.profitMultiplerUpgrade;
    }
}
