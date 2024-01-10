using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//added stuff
using UnityEngine.UI;
using TMPro;

public class totalMoneyScript : MonoBehaviour
{
    public float totalMoney = 0.00f;

    //instantiate text component
    TextMeshProUGUI totalMoneyText;


    // Start is called before the first frame update
    void Start()
    {
        //get text component
        totalMoneyText = transform.Find("Canvas/totalMoneyText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //every frame its text will be whatever value the totalMoney double is
        totalMoneyText.text = totalMoney.ToString();

    }
}
