using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class managerScript : MonoBehaviour
{
    [SerializeField] Slider loadingBar;
    [SerializeField] totalMoneyScript totalMoneyObject;
    [SerializeField] Button businessManagerButton;
    [SerializeField] Button businessActivateButton;
    [SerializeField] GameObject managerBlock;
    [SerializeField] float fillDuration = 1f; // Time in seconds to fill the loading bar
    [SerializeField] float baseProfit = 1f; // Amount of money added when loading bar is filled
    [SerializeField] float unlockAmount; // Amount of money added when loading bar is filled

   // [SerializeField] private businessScript myBusiness;

    private bool isActive = false;
    private bool isManagerUnlocked = false;
    private Image buttonImage;

    private void Start()
    {
        // Initially, disable the manager button
        businessManagerButton.interactable = false;

        // Get the Image component from the GameObject that contains the managerScript component
        buttonImage = businessManagerButton.GetComponent<Image>();

        // Set the color of the button's image to grey
        buttonImage.color = Color.grey;

        if (managerBlock == null)
        {
            Debug.LogError("managerBlock is not assigned on " + gameObject.name);
        }

    }


    private void Update()
    {
        // Check if the manager is active and fill the loading bar
        if (isActive)
        {
            FillLoadingBar();
        }
        if(!isManagerUnlocked && totalMoneyObject.totalMoney >= unlockAmount) // gets the manager button to be clickable
        {
            Debug.Log("Manager Unlocked!");
            isManagerUnlocked = true;
            businessManagerButton.interactable = true;


            // Set the color of the button's image to pink
            buttonImage.color = new Color(0.95f, 0.67f, 0.84f);
        }
    }

    public void ToggleBusinessManager()
    {
      
        // If manager is active, start the continuous process
        if (isActive)
        {
            StartCoroutine(ContinuousProcess());
        }
    }

    IEnumerator ContinuousProcess()
    {
        while (isActive)
        {
            // Fill the loading bar continuously
            FillLoadingBar();

            // Wait for a brief period before filling again
            yield return new WaitForSeconds(fillDuration);
        }
    }

    private void FillLoadingBar()
    {
        // Increment loading bar value gradually
        loadingBar.value += Time.deltaTime / fillDuration;

        // Ensure the loading bar is completely filled
        if (loadingBar.value >= 1f)
        {
            loadingBar.value = 1f;

            // Add to the total money
            totalMoneyObject.totalMoney += baseProfit;

            // Reset loading bar value
            loadingBar.value = 0f;
        }
    }

    // This method is called when the player accumulates $10
    public void UnlockManager()
    {
        if (managerBlock == null)
        {
            Debug.LogError("Attempted to unlock manager, but managerBlock is not assigned.");
            return; // Exit the function if managerBlock is null to avoid the error
        }

        if (totalMoneyObject.totalMoney >= unlockAmount)
        {
            // Deduct $10 from the total money
            totalMoneyObject.totalMoney -= unlockAmount;  
            isActive = true; // start auto filling progress bar
            businessActivateButton.interactable = false; // disable the manual clickable button 


            // Get the parent GameObject of the business1ManagerButton
           // Transform managerPrefabTransform = managerBlock;
      

            // Get the index of the manager prefab in the layout group
            int index = managerBlock.transform.GetSiblingIndex();

            // Update positions of remaining managers
            UpdateManagerPositions(index);

            // Destroy the parent GameObject but wait 1 second to make sure the layout gets rearranged correctly
            Destroy(managerBlock, 1f);


            // Optional: if you have UI or other elements that need to update immediately after this destruction
            // Make sure to check if the parent is not null

            if (managerBlock.transform.parent != null)
            {
                // Force the layout group to update immediately
                LayoutRebuilder.ForceRebuildLayoutImmediate(managerBlock.transform.parent.GetComponent<RectTransform>());
            }
        }
    }

    private void UpdateManagerPositions(int removedIndex)
    {
      
        // Get the parent transform of the manager prefabs
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
