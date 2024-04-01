using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class checkManagerAnimations : MonoBehaviour
{
    //get each business to access business Cost in case we ever want to modify them later
    [SerializeField] GameObject businessManagerObject1;
    [SerializeField] GameObject businessManagerObject2;
    [SerializeField] GameObject businessManagerObject3;
    [SerializeField] GameObject businessManagerObject4;
    [SerializeField] GameObject businessManagerObject5;
    [SerializeField] GameObject businessManagerObject6;
    [SerializeField] GameObject businessManagerObject7;
    [SerializeField] GameObject businessManagerObject8;

    managerScript managerScript1;
    managerScript managerScript2;
    managerScript managerScript3;
    managerScript managerScript4;
    managerScript managerScript5;
    managerScript managerScript6;
    managerScript managerScript7;
    managerScript managerScript8;

    [SerializeField] Canvas unlockedCanvas1;
    [SerializeField] Canvas unlockedCanvas2;
    [SerializeField] Canvas unlockedCanvas3;
    [SerializeField] Canvas unlockedCanvas4;
    [SerializeField] Canvas unlockedCanvas5;
    [SerializeField] Canvas unlockedCanvas6;
    [SerializeField] Canvas unlockedCanvas7;
    [SerializeField] Canvas unlockedCanvas8;

    totalMoneyScript totalMoneyScript; // script controlling total money
    [SerializeField] Animator openManagerPanelAnimator;



    private bool allAnimationsPlayed = false;
    private bool animation1Played = false;
    private bool animation2Played = false;
    private bool animation3Played = false;
    private bool animation4Played = false;
    private bool animation5Played = false;
    private bool animation6Played = false;
    private bool animation7Played = false;
    private bool animation8Played = false;



    private void Awake()
    {
        //there is only 8 so we can just instantiate, perhaps keep a list if game were to scale more than 8 businesses / managers

        //get the scripts of each manager to retrive its unlockCost
        managerScript1 = businessManagerObject1.GetComponent<managerScript>();
        managerScript2 = businessManagerObject2.GetComponent<managerScript>();
        managerScript3 = businessManagerObject3.GetComponent<managerScript>();
        managerScript4 = businessManagerObject4.GetComponent<managerScript>();
        managerScript5 = businessManagerObject5.GetComponent<managerScript>();
        managerScript6 = businessManagerObject6.GetComponent<managerScript>();
        managerScript7 = businessManagerObject7.GetComponent<managerScript>();
        managerScript8 = businessManagerObject8.GetComponent<managerScript>();

        totalMoneyScript = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //gets script to access money variable
    }




    // Start is called before the first frame update
    //void Start()
    //{

    //}




    // Update is called once per frame
    void Update()
    {
        if (allAnimationsPlayed is false)
        {

            // Check for animation 1
            if (managerScript1.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas1.isActiveAndEnabled && !animation1Played)
            {
                playAnimation();
                animation1Played = true;
            }

            // Check for animation 2
            if (managerScript2.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas2.isActiveAndEnabled && !animation2Played)
            {
                playAnimation();
                animation2Played = true;
            }

            // Check for animation 3
            if (managerScript3.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas3.isActiveAndEnabled && !animation3Played)
            {
                playAnimation();
                animation3Played = true;
            }

            // Check for animation 4
            if (managerScript4.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas4.isActiveAndEnabled && !animation4Played)
            {
                playAnimation();
                animation4Played = true;
            }

            // Check for animation 5
            if (managerScript5.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas5.isActiveAndEnabled && !animation5Played)
            {
                playAnimation();
                animation5Played = true;
            }

            // Check for animation 6
            if (managerScript6.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas6.isActiveAndEnabled && !animation6Played)
            {
                playAnimation();
                animation6Played = true;
            }

            // Check for animation 7
            if (managerScript7.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas7.isActiveAndEnabled && !animation7Played)
            {
                playAnimation();
                animation7Played = true;
            }

            // Check for animation 8
            if (managerScript8.unlockAmount <= totalMoneyScript.totalMoney &&
                unlockedCanvas8.isActiveAndEnabled && !animation8Played)
            {
                playAnimation();
                animation8Played = true;
                allAnimationsPlayed = true; 
            }
        }
    }


    void playAnimation()
    {
        openManagerPanelAnimator.SetTrigger("TriggerManagerUnlock");    //play animation
    }
}
