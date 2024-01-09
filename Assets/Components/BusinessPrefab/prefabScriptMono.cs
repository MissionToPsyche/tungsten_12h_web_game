using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ADDED
using UnityEngine.UI;
using TMPro;


public class prefabScriptMono : MonoBehaviour
{
    //public GameObject myBusinessPrefabObject;  //no need to make object since its attached to prefab      

    public float secondsToFinish = 10f;     //variable dependent on business
    public double profit = 1.00;


    public double upgradeCost;
    public int scale; //??
    public double unlockCost;
    public int level = 0;


    //COMPONENTS
    Button upgradeButton;
    Button activateButton;

    Slider loadingBar;

    TextMeshProUGUI levelText;  

    // Start is called before the first frame update
    void Start()
    {
        activateButton = transform.Find("Canvas/activateButton").GetComponent<Button>();      //create ACTIVATE BUTTON OBJECT
        upgradeButton = transform.Find("Canvas/upgradeButton").GetComponent<Button>();        //create UPGRADE BUTTON OBJECT

        loadingBar = transform.Find("Canvas/loadingBar").GetComponent<Slider>();              //create LOADING BAR OBJECT

        levelText = transform.Find("Canvas/level").GetComponent<TextMeshProUGUI>();                       //create LEVEL TEXT OBJECT  


        activateButton.onClick.AddListener(activateButtonHandler);     //activateButton listener (can initiate in global)
        upgradeButton.onClick.AddListener(upgradeButtonHandler);     //activateButton listener (can initiate in global)

    }

    //"upgradeButton" Handler
    void upgradeButtonHandler()
    {
        //button needs to be clickable only when enough money is had
        level++;
        if (levelText != null)
        {
            levelText.text = level.ToString();
        }
        else
        {
            Debug.LogError("Text component is null. Make sure it is assigned in the Unity Editor.");
        }
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
        yield break;                            // End the coroutine
    }

    // Update is called once per frame
    void Update()
    {

    }
}
