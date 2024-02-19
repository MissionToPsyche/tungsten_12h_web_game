using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePrefab : MonoBehaviour
{
    [SerializeField] GameObject varibleObject;
    businessVariables businessVariable;
    totalMoneyScript totalMoneyObject;

    private void Awake()
    {
        businessVariable = varibleObject.GetComponent<businessVariables>();
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();
    }

    public void updateMultiplier()
    {
        if (totalMoneyObject.totalMoney <= businessVariable.upgradeCost)
        {
            businessVariable.profitMultiplerUpgrade *= 3;
        }
        else
        {
            return;
        }
       
    }
}
