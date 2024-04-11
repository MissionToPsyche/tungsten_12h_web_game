using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class unlockCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;

    totalMoneyScript totalMoneyScript;


    //[SerializeField] TextMeshProUGUI businessNameText;
    [SerializeField] TextMeshProUGUI unlockCostText;

    void Awake()
    {
        totalMoneyScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();



        var (formattedMoney, numericalPrefix) = totalMoneyScript.FormatMoney(businessVariables.unlockCost);

        //businessNameText.text = businessVariables.businessName; //will show classified and display name when unlocked
        unlockCostText.text = formattedMoney + " " + numericalPrefix + "$"; //update upgrade cost text to new cost
    }
}
