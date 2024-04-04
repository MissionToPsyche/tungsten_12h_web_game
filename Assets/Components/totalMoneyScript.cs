using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//added stuff
using UnityEngine.UI;
using TMPro;
using System;

public class totalMoneyScript : MonoBehaviour
{
    public double totalMoney = 0.00; //double reachs 10^308 which is more than enough for our game

    //instantiate text component
    [SerializeField] TextMeshProUGUI totalMoneyText;




    // Start is called before the first frame update
    void Start()
    {
        //get text component
        totalMoneyText = transform.Find("Canvas/totalMoneyText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        var (formattedValue, numericalPrefix) = FormatMoney(totalMoney); //format money before displaying

        //every frame its text will be whatever value the totalMoney double is
        totalMoneyText.text = formattedValue + " " + numericalPrefix + "$";

    }



    public static (string, string) FormatMoney(double money)  //takes in double, return string, string
    {
        if (Math.Abs(money) >= 1E15)
        {
            // Display in quadrillions with two decimal places
            return ((money / 1E15).ToString("N2"), "Quadrillion");
        }
        else if (Math.Abs(money) >= 1E12 && Math.Abs(money) < 1E15)
        {
            // Display in trillions with two decimal places
            return ((money / 1E12).ToString("N2"), "Trillion");
        }
        else if (Math.Abs(money) >= 1E9 && Math.Abs(money) < 1E12)
        {
            // Display in billions with two decimal places
            return ((money / 1E9).ToString("N2"), "Billion");
        }
        else if (Math.Abs(money) >= 1E6 && Math.Abs(money) < 1E9)
        {
            // Display in millions with two decimal places
            return ((money / 1E6).ToString("N2"), "Million");
        }
        else
        {
            // Format as normal with commas and two decimal places
            return (money.ToString("N2"), "");
        }
    }



}
