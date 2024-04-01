using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class managerScript : MonoBehaviour
{
    //dont need things below as it utilized in businessPrefab and handled there
    //[SerializeField] Slider loadingBar; // progress bar
    //[SerializeField] float fillDuration = 1f; // Time in seconds to fill the loading bar
    //[SerializeField] float baseProfit = 1f; // Amount of money added when loading bar is filled
    //[SerializeField] Button businessActivateButton; // the businesses button
    //private bool isActive = false;  // true if manager was hired
    //private bool isManagerUnlocked = false; // true if manager is unlocked and ready for purchase
    //private IEnumerator coroutineReference = null; // Store reference to the coroutine


    totalMoneyScript totalMoneyScript; // script controlling total money
    [SerializeField] Button businessManagerButton; // button to hire manager
    [SerializeField] GameObject managerBlock; // manager pic, description, and hire button

    //moved into checkAnimations
    //[SerializeField] Animator openManagerPanelAnimator;


    [SerializeField] GameObject variableObject; // business variables that are attached to each businessPrefab
    businessVariables businessVariables;

    [SerializeField] GameObject activateButtonObject;
    activateButtonScript activateButtonScript; //this script is simply used to call the infiniteCoroutine function from that business

    [SerializeField] Canvas unlockedCanvas; //used to check if a business is unlocked to before you hire the manaager

    public float unlockAmount; // Amount needed to unlock manager

    private Image buttonImage; // for getting the hire button image for the manager.

    //private bool animationHasPlayed = false;


    //this runs before start, access the scripts like money and button here
    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();

        //get activateButton script for startInfiniteCoroutine function
        activateButtonScript = activateButtonObject.GetComponent<activateButtonScript>();

        //StartCoroutine(checkToPlayAnimation());         //continously check if a manager is unlockable to play an animation and then never play the animation for
                                                        //that manager again
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

        /// referencing amandas stuff

        // Check if the manager is active and fill the loading bar
        //if (isActive)
        //{
        //   // Debug.Log($"[Update] Manager {businessActivateButton.name} is active. Loading bar current value: {loadingBar.value}");
        //    FillLoadingBar();
        //}
        //if(!isManagerUnlocked && totalMoneyObject.totalMoney >= unlockAmount) // gets the manager button to be clickable
        //{
        //    //Debug.Log("Manager Unlocked!");

        //    isManagerUnlocked = true;
        //    businessManagerButton.interactable = true; // make the businessManager button clickable

        //the animations were running in controller so logic was split into there for less coupling

        //    // Trigger the unlock notice animation.
        //    // The manager panel button should pulse and the text should change color for a few seconds to alert player that a manager is unlocked. 
        //    if (openManagerPanelAnimator != null)
        //    {
        //        openManagerPanelAnimator.SetTrigger("TriggerManagerUnlock");
        //    }

        //    // Set the color of the button's image to pink
        //    buttonImage.color = new Color(0.647f, 0.24f, 0.357f);
        //   // Debug.Log($"[Update] Manager {businessActivateButton.name} is now unlocked.");
        //}

    }


    //cant see where ToggleBusinessManager is being used, removing it after current implementation did no effect
    //public void ToggleBusinessManager()
    //{

    //    // If manager is active, start the continuous process
    //    if (isActive)
    //    {

    //        coroutineReference = ContinuousProcess();
    //        StartCoroutine(ContinuousProcess());
    //    }
    //}



    //continousProcess is now being Handled in the businessPrefab so this is deleted there would be no need for controllers
    // IEnumerator ContinuousProcess()
    // {
    //// Debug.Log($"[ContinuousProcess] Started for {businessActivateButton.name}");
    // while (isActive)
    //     {
    //         // Fill the loading bar continuously
    //         FillLoadingBar();
    //    // Debug.Log($"[ContinuousProcess] {businessActivateButton.name} loading bar fill coroutine is running.");
    //     // Wait for a brief period before filling again
    //     yield return new WaitForSeconds(fillDuration);
    //     }
    // }

    //the fill loading bar is essentially moved to the businessPrefab and utilizing the loading bar there, which is dynamic and can adapt to milestones
    //private void FillLoadingBar()
    //{
    //    // Increment loading bar value gradually
    //    loadingBar.value += Time.deltaTime / fillDuration;
    //    //Debug.Log($"[FillLoadingBar] {businessActivateButton.name} loading bar filling. Current value: {loadingBar.value}");


    //    // Ensure the loading bar is completely filled
    //    if (loadingBar.value >= 1f)
    //    {
    //       // Debug.Log($"[FillLoadingBar] {businessActivateButton.name} - Final value before reset: {loadingBar.value}");
    //        loadingBar.value = 1f;

    //        businessVariables = variableObject.GetComponent<businessVariables>();
    //        int level = businessVariables.level; // get how many stores(level) the player has so the total money will correctly reflect 

    //        // Add to the total money
    //        totalMoneyObject.totalMoney += (baseProfit * level);

    //      //  Debug.Log($"{businessActivateButton.name} added {(baseProfit * level)} to total money.");

    //        // Reset loading bar value
    //        loadingBar.value = 0f;


    //        // Debug to check if any other code is resetting the bar
    //    }
    //    else if (loadingBar.value == 0f)
    //    {
    //        //Debug.Log($"[FillLoadingBar] {businessActivateButton.name} - Loading bar was reset externally.");
    //    }

    //}





    //if the manager is clicked this is called
    //this should simply call the infinite coroutine from the corresponding business
    //this is only clickable if the update makes it interactable, so no need to check if we have enough money since update does that
    public void UnlockManager()
    {
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
