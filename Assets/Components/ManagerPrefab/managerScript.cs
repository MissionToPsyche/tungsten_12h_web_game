using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class managerScript : MonoBehaviour
{
    [SerializeField] Slider loadingBar; // progress bar
    [SerializeField] totalMoneyScript totalMoneyObject; // script controlling total money
    [SerializeField] Button businessManagerButton; // button to hire manager
    [SerializeField] Button businessActivateButton; // the businesses button
    [SerializeField] GameObject managerBlock; // manager pic, description, and hire button
    [SerializeField] float fillDuration = 1f; // Time in seconds to fill the loading bar
    [SerializeField] float baseProfit = 1f; // Amount of money added when loading bar is filled
    [SerializeField] float unlockAmount; // Amount needed to unlock manager
    [SerializeField] Animator openManagerPanelAnimator; 
    [SerializeField] GameObject variableObject; // business variables that are attached to each businessPrefab
    businessVariables businessVariables;
    

    private bool isActive = false;  // true if manager was hired
    private bool isManagerUnlocked = false; // true if manager is unlocked and ready for purchase
    private Image buttonImage; // for getting the hire button image for the manager.

    private IEnumerator coroutineReference = null; // Store reference to the coroutine


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
        
        // Check if the manager is active and fill the loading bar
        if (isActive)
        {
           // Debug.Log($"[Update] Manager {businessActivateButton.name} is active. Loading bar current value: {loadingBar.value}");
            FillLoadingBar();
        }
        if(!isManagerUnlocked && totalMoneyObject.totalMoney >= unlockAmount) // gets the manager button to be clickable
        {
            Debug.Log("Manager Unlocked!");

            isManagerUnlocked = true;
            businessManagerButton.interactable = true; // make the businessManager button clickable

            // Trigger the unlock notice animation.
            // The manager panel button should pulse and the text should change color for a few seconds to alert player that a manager is unlocked. 
            if (openManagerPanelAnimator != null)
            {
                openManagerPanelAnimator.SetTrigger("TriggerManagerUnlock");
            }

            // Set the color of the button's image to pink
            buttonImage.color = new Color(0.647f, 0.24f, 0.357f);
           // Debug.Log($"[Update] Manager {businessActivateButton.name} is now unlocked.");
        }
    }

        
    

    public void ToggleBusinessManager()
    {
      
        // If manager is active, start the continuous process
        if (isActive)
        {
       
            coroutineReference = ContinuousProcess();
            StartCoroutine(ContinuousProcess());
        }
    }

    IEnumerator ContinuousProcess()
    {
    Debug.Log($"[ContinuousProcess] Started for {businessActivateButton.name}");
    while (isActive)
        {
            // Fill the loading bar continuously
            FillLoadingBar();
       // Debug.Log($"[ContinuousProcess] {businessActivateButton.name} loading bar fill coroutine is running.");
        // Wait for a brief period before filling again
        yield return new WaitForSeconds(fillDuration);
        }
    }

    private void FillLoadingBar()
    {
        // Increment loading bar value gradually
        loadingBar.value += Time.deltaTime / fillDuration;
        //Debug.Log($"[FillLoadingBar] {businessActivateButton.name} loading bar filling. Current value: {loadingBar.value}");

        // Use a threshold to account for floating-point precision issues
        float fillThreshold = 0.999f;

        // Ensure the loading bar is completely filled
        if (loadingBar.value >= 1f)
        {
            Debug.Log($"[FillLoadingBar] {businessActivateButton.name} - Final value before reset: {loadingBar.value}");
            loadingBar.value = 1f;

            businessVariables = variableObject.GetComponent<businessVariables>();
            int level = businessVariables.level; // get how many stores(level) the player has so the total money will correctly reflect 

            // Add to the total money
            totalMoneyObject.totalMoney += (baseProfit * level);

            Debug.Log($"{businessActivateButton.name} added {(baseProfit * level)} to total money.");

            // Reset loading bar value
            loadingBar.value = 0f;


            // Debug to check if any other code is resetting the bar
        }
        else if (loadingBar.value == 0f)
        {
            Debug.Log($"[FillLoadingBar] {businessActivateButton.name} - Loading bar was reset externally.");
        }
            
}

    
    public void UnlockManager()
    {
    Debug.Log($"[UnlockManager] Attempting to unlock manager {businessActivateButton.name}.");
    if (totalMoneyObject.totalMoney >= unlockAmount)
        {
      
        // Deduct $unlockAmount from the total money
        totalMoneyObject.totalMoney -= unlockAmount;  
            isActive = true; // start auto filling progress bar
            businessActivateButton.interactable = false; // disable the manual clickable button 


            // Get the index of the manager prefab in the layout group
            int index = managerBlock.transform.GetSiblingIndex();

        Debug.Log($"[UnlockManager] Manager {businessActivateButton.name} unlocked. Total money after unlock: {totalMoneyObject.totalMoney}");

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
        // Reset the coroutine reference when the manager is unlocked
        coroutineReference = null;

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
