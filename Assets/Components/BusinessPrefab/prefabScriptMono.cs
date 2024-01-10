using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ADDED
using UnityEngine.UI;
using TMPro;


public class prefabScriptMono : MonoBehaviour
{
    //public GameObject myBusinessPrefabObject;  //no need to make object since its attached to prefab      

    public float secondsToFinish = 1.00f;     //variable dependent on business
    public float baseProfit = 1.00f;


    public float upgradeCost = 1.00f; //cost to upgrade (should be modifed after every level)
    public float upgradeCostScale = 1.20f; //(increase 1/5 each level) //how much the cost of upgrade should increase per level
    public float profitIncreasePerLevel = 1.00f;           //each level will increase profit of business by this amount (linear)
                                                                                                                                                                                                                                                                                                                                    
    public float unlockCost = 0;                    //still have to click at 0 to unlock                    
    public int level = 1;                           //base level is one


    //COMPONENTS
    Button upgradeButton;
    Button activateButton;

    Slider loadingBar;

    TextMeshProUGUI levelText;

    totalMoneyScript totalMoneyObjectScript;

    // Start is called before the first frame update
    void Start()
    {
        //these components within its own hierarchy
        activateButton = transform.Find("Canvas/activateButton").GetComponent<Button>();      //reference ACTIVATE BUTTON OBJECT
        upgradeButton = transform.Find("Canvas/upgradeButton").GetComponent<Button>();        //reference UPGRADE BUTTON OBJECT
        loadingBar = transform.Find("Canvas/loadingBar").GetComponent<Slider>();              //reference LOADING BAR OBJECT
        levelText = transform.Find("Canvas/level").GetComponent<TextMeshProUGUI>();           //reference LEVEL TEXT OBJECT

        //objects outside of hierarchy
        totalMoneyObjectScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject

        activateButton.onClick.AddListener(activateButtonHandler);     //activateButton listener (can initiate in global)
        upgradeButton.onClick.AddListener(upgradeButtonHandler);     //activateButton listener (can initiate in global)
    }

    //"upgradeButton" Handler
    void upgradeButtonHandler()
    {
        //button needs to be clickable only when enough money is had
        level++;
        levelText.text = level.ToString();          //update level text
        baseProfit += profitIncreasePerLevel;       //increase profit of business 

        totalMoneyObjectScript.totalMoney -= upgradeCost;  //subtract cost to upgrade from total money //SUBTRACT MONEY BEFORE YOU MODIFY UPGRADE COST BELOW     

        upgradeCost *= upgradeCostScale;            //increase cost to upgrade

    }

    //"activateButton" Handler
    void activateButtonHandler()
    {
        activateButton.interactable = false;              //button will UNCLICKABLE since its has started loading bar
        StartCoroutine(MyCoroutine());              //start coroutine
    }


    IEnumerator MyCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < secondsToFinish)
        {
            // Interpolate the value from 0 to 1 based on the elapsed time
            float fillValue = Mathf.Lerp(0f, 1f, elapsedTime / secondsToFinish);

            // Set the loading bar value
            loadingBar.value = fillValue;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        loadingBar.value = 0f;                  //reset the loading bar
        activateButton.interactable = true;     //make button clickable again

        //need to update total money object
        totalMoneyObjectScript.totalMoney += baseProfit;

        yield break;                            // End the coroutine
    }

    // Update is called once per frame
    void Update()
    {
        //if upgrade cost is less than total money make upgrade button interactable
        if (upgradeCost <= totalMoneyObjectScript.totalMoney)
        {
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
        }
    }
}
