using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class businessVariables : MonoBehaviour
{
    public string businessName = "no name";

    //this script is attached to an empty gameobject to simply store all variables of each business object

    public double unlockCost = 0;                    //still have to click at 0 to unlock                    

    public float secondsToFinish = 1.00f;     //variable dependent on business
    public float baseProfit = 1.00f;


    public float upgradeCost = 1.00f; //cost to upgrade (should be modifed after every level)
    public float upgradeCostScale = 1.07f; //(increase 1/5 each level) //how much the cost of upgrade should increase per level
    public float profitIncreasePerLevel = 1.00f;           //each level will increase profit of business by this amount (linear)

    public int level = 1;                           //base level is one


    public float profitMultiplerUpgrade = 1.00f; //in future when we add buttons to increase cost of each business with milestone this will get changed



}
