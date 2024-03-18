using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class unlockCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;

    [SerializeField] TextMeshProUGUI businessNameText;
    [SerializeField] TextMeshProUGUI unlockCostText;
    void Awake()
    {
        businessVariables = variableObject.GetComponent<businessVariables>();

        businessNameText.text = businessVariables.businessName;
        unlockCostText.text = businessVariables.unlockCost.ToString() + "$"; //update upgrade cost text to new cost
    }
}
