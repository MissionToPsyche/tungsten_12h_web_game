using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//added
using UnityEngine.UI; //text, buttons, slider etc


public class unlockButtonScript : MonoBehaviour
{
    //ALL THESE COMPONENTS ARE WITHIN THE HIERARCHY

    [SerializeField] GameObject variableObject;
    businessVariables businessVariables;
    //IS THERE A BETTER WAY TO BRING A SCRIPT INTO THIS SCRIPT SINCE I ONLY NEED THE VARIABLES AND DO NOT WANT TO GET THE OBJECT TO FIND SCRIPT

    [SerializeField] GameObject unlockCanvas;       //canvas to hide (the unlock canvas)
    [SerializeField] GameObject unlockedCanvas;     //canvas to display (after unlocked)

    [SerializeField] Button unlockButton;           //button used to make interactable/uninteractable depending on current money

    private dialogueTrigger dialogueTrigger;        //since dialogueTrigger a monoscript we attach and can get component

    //SAY I WANT TO ACCESS AN OBJECT THAT IS OUTSIDE THE HIERARCHY LIKE THIS
    //DO I JUST SIMPLY FIND IT??
    totalMoneyScript totalMoneyObject;


    bool unlockableDialogueShown = false;

    private void Awake()
    {
        //manually find totalMoneyObject and get script to access variable
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //note this gets only the gameobject
        businessVariables = variableObject.GetComponent<businessVariables>();
        dialogueTrigger = GetComponent<dialogueTrigger>();

    }

    public void unlockBusiness()
    {
        unlockCanvas.SetActive(false);          //hide the canvas to unlock
        unlockedCanvas.SetActive(true);         //display canvas to interact with business object
    }

    // Update is called once per frame
    void Update()
    {
        //allow clickable button if their is enough money
        if (businessVariables.unlockCost <= totalMoneyObject.totalMoney)
        {
            if (unlockableDialogueShown == false)
            {
                unlockableDialogueShown=true;
                dialogueTrigger.triggerDialogue();
            }
            unlockButton.interactable = true;

        } else
        {
            unlockButton.interactable = false;
        }
    }
}
