using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class managerScript : MonoBehaviour
{
    totalMoneyScript totalMoneyScript; // script controlling total money
    [SerializeField] Button businessManagerButton; // button to hire manager
    [SerializeField] GameObject managerBlock; // manager pic, description, and hire button


    [SerializeField] GameObject variableObject; // business variables that are attached to each businessPrefab
    businessVariables businessVariables;

    [SerializeField] GameObject activateButtonObject;
    activateButtonScript activateButtonScript; //this script is simply used to call the infiniteCoroutine function from that business

    [SerializeField] Canvas unlockedCanvas; //used to check if a business is unlocked to before you hire the manaager

    public float unlockAmount; // Amount needed to unlock manager

    private Image buttonImage; // for getting the hire button image for the manager.
    [SerializeField] TextMeshProUGUI managerNameText;
    [SerializeField] TextMeshProUGUI unlockCostText;
    [SerializeField] TextMeshProUGUI runXBusinessText;

    [SerializeField] string managerName = "default";




    //this runs before start, access the scripts like money and button here
    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();

        //get activateButton script for startInfiniteCoroutine function
        activateButtonScript = activateButtonObject.GetComponent<activateButtonScript>();

        //update UI of prefab

        //set manager name
        managerNameText.text = managerName;

        //set "runs [businessName]"
        runXBusinessText.text = "Runs " + businessVariables.businessName;

        //set cost to unlock
        unlockCostText.text = "Costs " + unlockAmount.ToString();
    }

    private void Start()
    {
        // Initially disable the manager button
        businessManagerButton.interactable = false;

        // Get the Image component from the businessMangerButton
        buttonImage = businessManagerButton.GetComponent<Image>();

        // Set the color of the button's image to grey
        buttonImage.color = Color.grey;
    }



    private void Update()
    {
        //no need for "isActive" since the automatic loading bar was moved to the prefab so when this object is destroyed, and utilizing the loading bar from there
        if (unlockAmount <= totalMoneyScript.totalMoney && unlockedCanvas.isActiveAndEnabled) //if we have enough money and corresponding business is unlocked
        {
            businessManagerButton.interactable = true;                        //make the businessManager button clickable
            buttonImage.color = new Color(0.647f, 0.24f, 0.357f);             //set color to red when purchaseable

        }
        else  //we dont have enough money to unlock
        {
            businessManagerButton.interactable = false; //the button should not be interactable without enough money
            buttonImage.color = Color.grey;             //turn gray

        }

    }




    //if the manager is clicked this is called
    //this should simply call the infinite coroutine from the corresponding business
    //this is only clickable if the update makes it interactable, so no need to check if we have enough money since update does that
    public void UnlockManager()
    {
        Debug.Log("unlocked manager");
        //call infiniteCoroutine from corresponding business
        activateButtonScript.startInfiniteCoroutine();

        // Deduct $unlockAmount from the total money
        totalMoneyScript.totalMoney -= unlockAmount;

        // Get the index of the manager prefab in the layout group
        int index = managerBlock.transform.GetSiblingIndex();

        // Update positions of remaining managers in the scrollview
        UpdateManagerPositions(index);

        // Destroy the manager that was hired but wait 1 second to make sure the layout gets rearranged correctly
        Destroy(managerBlock, 1f);

        if (managerBlock.transform.parent != null)
        {
            // Force the layout group to update immediately. Move up the remaining managers in the scrollview
            LayoutRebuilder.ForceRebuildLayoutImmediate(managerBlock.transform.parent.GetComponent<RectTransform>());
        }
    }

    private void UpdateManagerPositions(int removedIndex)
    {
        // Get the parent transform of the manager prefabs which is the ManagerContainer
        Transform managerContainer = businessManagerButton.transform.parent.parent.parent;

        // Loop through each child of the manager container
        for (int i = removedIndex + 1; i < managerContainer.childCount; i++)
        {
            // Get the transform of the current manager prefab
            Transform managerPrefab = managerContainer.GetChild(i);

            // Move the manager prefab and its entire hierarchy up in the hierarchy
            managerPrefab.SetSiblingIndex(i - 1);
        }
    }

}
