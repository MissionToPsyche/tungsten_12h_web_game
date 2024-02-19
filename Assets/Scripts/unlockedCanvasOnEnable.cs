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



    private void Awake()
    {
        // Assuming businessVariables script is attached to the variableObject
        businessVariables = variableObject.GetComponent<businessVariables>();
    }


    //"OnEnable" is activated when a GAMEOBJECT is ".setActive(true)";
    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");

        upgradeCostText.text = businessVariables.upgradeCost.ToString() + "$"; //update upgrade cost text to new cost
        levelText.text = businessVariables.level.ToString();

    }
}
