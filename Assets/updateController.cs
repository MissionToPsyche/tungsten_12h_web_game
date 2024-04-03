using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateController : MonoBehaviour
{
    [SerializeField] GameObject Upgrade1;
    [SerializeField] GameObject Upgrade2;
    [SerializeField] GameObject Upgrade3;
    [SerializeField] GameObject Upgrade4;
    [SerializeField] GameObject Upgrade5;
    [SerializeField] GameObject Upgrade6;
    [SerializeField] GameObject Upgrade7;
    [SerializeField] GameObject Upgrade8;

    //private bool playerAcknowledged = false;

    private float costUpgrade1;
    private float costUpgrade2;
    private float costUpgrade3;
    private float costUpgrade4;
    private float costUpgrade5;
    private float costUpgrade6;
    private float costUpgrade7;
    private float costUpgrade8;

    UpgradePrefab upgradePrefab1;
    UpgradePrefab upgradePrefab2;
    UpgradePrefab upgradePrefab3;
    UpgradePrefab upgradePrefab4;
    UpgradePrefab upgradePrefab5;
    UpgradePrefab upgradePrefab6;
    UpgradePrefab upgradePrefab7;
    UpgradePrefab upgradePrefab8;

    private bool upgradeBool1 = false;
    private bool upgradeBool2 = false;
    private bool upgradeBool3 = false;
    private bool upgradeBool4 = false;
    private bool upgradeBool5 = false;
    private bool upgradeBool6 = false;
    private bool upgradeBool7 = false;
    private bool upgradeBool8 = false;

    private float[] upgrade1 = new float[3];
    private float[] upgrade2 = new float[3];
    private float[] upgrade3 = new float[3];
    private float[] upgrade4 = new float[3];
    private float[] upgrade5 = new float[3];
    private float[] upgrade6 = new float[3];
    private float[] upgrade7 = new float[3];
    private float[] upgrade8 = new float[3];


    [SerializeField] Animator buttonAnimator;
    totalMoneyScript totalMoneyObject;
    private void Awake()
    {
        totalMoneyObject = GameObject.Find("totalMoney").GetComponent<totalMoneyScript>();    //gets script to access money variable
        upgradePrefab1 = Upgrade1.GetComponent<UpgradePrefab>();
        upgradePrefab2 = Upgrade2.GetComponent<UpgradePrefab>();
        upgradePrefab3 = Upgrade3.GetComponent<UpgradePrefab>();
        upgradePrefab4 = Upgrade4.GetComponent<UpgradePrefab>();
        upgradePrefab5 = Upgrade5.GetComponent<UpgradePrefab>();
        upgradePrefab6 = Upgrade6.GetComponent<UpgradePrefab>();
        upgradePrefab7 = Upgrade7.GetComponent<UpgradePrefab>();
        upgradePrefab8 = Upgrade8.GetComponent<UpgradePrefab>();

        upgrade1[0] = upgradePrefab1.costUp1;
        upgrade1[1] = upgradePrefab1.costUp2;
        upgrade1[2] = upgradePrefab1.costUp3;
        costUpgrade1 = upgrade1[0];

        upgrade2[0] = upgradePrefab2.costUp1;
        upgrade2[1] = upgradePrefab2.costUp2;
        upgrade2[2] = upgradePrefab2.costUp3;
        costUpgrade2 = upgrade2[0];

        upgrade3[0] = upgradePrefab3.costUp1;
        upgrade3[1] = upgradePrefab3.costUp2;
        upgrade3[2] = upgradePrefab3.costUp3;
        costUpgrade3 = upgrade3[0];

        upgrade4[0] = upgradePrefab4.costUp1;
        upgrade4[1] = upgradePrefab4.costUp2;
        upgrade4[2] = upgradePrefab4.costUp3;
        costUpgrade4 = upgrade4[0];

        upgrade5[0] = upgradePrefab5.costUp1;
        upgrade5[1] = upgradePrefab5.costUp2;
        upgrade5[2] = upgradePrefab5.costUp3;
        costUpgrade5 = upgrade5[0];

        upgrade6[0] = upgradePrefab6.costUp1;
        upgrade6[1] = upgradePrefab6.costUp2;
        upgrade6[2] = upgradePrefab6.costUp3;
        costUpgrade6 = upgrade6[0];

        upgrade7[0] = upgradePrefab7.costUp1;
        upgrade7[1] = upgradePrefab7.costUp2;
        upgrade7[2] = upgradePrefab7.costUp3;
        costUpgrade7 = upgrade7[0];

        upgrade8[0] = upgradePrefab8.costUp1;
        upgrade8[1] = upgradePrefab8.costUp2;
        upgrade8[2] = upgradePrefab8.costUp3;
        costUpgrade8 = upgrade8[0];
    }

    // Update is called once per frame
    void Update()
    {

            //animation1 has played = false
            if (!upgradeBool1 && totalMoneyObject.totalMoney >= costUpgrade1)
            {
                upgradeBool1 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

                if (buttonAnimator != null)
                {
                    buttonAnimator.SetTrigger("TriggerManagerUnlock");
                }

            }
        if (!upgradeBool2 && totalMoneyObject.totalMoney >= costUpgrade2)
        {
            upgradeBool2 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool3 && totalMoneyObject.totalMoney >= costUpgrade3)
        {
            upgradeBool3 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool4 && totalMoneyObject.totalMoney >= costUpgrade4)
        {
            upgradeBool4 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool5 && totalMoneyObject.totalMoney >= costUpgrade5)
        {
            upgradeBool5 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool6 && totalMoneyObject.totalMoney >= costUpgrade6)
        {
            upgradeBool6 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool7 && totalMoneyObject.totalMoney >= costUpgrade7)
        {
            upgradeBool7 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }
        if (!upgradeBool8 && totalMoneyObject.totalMoney >= costUpgrade8)
        {
            upgradeBool8 = true;                //lock this if and only enable when you click the corresponding upgradePrefab

            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("TriggerManagerUnlock");
            }

        }


    }

    public void updateCost1() //on button click
    {
        costUpgrade1 = upgradePrefab1.upgradeTime <= 3 ? upgrade1[upgradePrefab1.upgradeTime - 1] : -1;
        upgradeBool1 = upgradePrefab1.upgradeTime <= 3 ? false : true;
    }

    public void updateCost2()
    {
        costUpgrade2 = upgradePrefab2.upgradeTime <= 3 ? upgrade2[upgradePrefab2.upgradeTime - 1] : -1;
        upgradeBool2 = false;

    }

    public void updateCost3()
    {
        costUpgrade3 = upgradePrefab3.upgradeTime <= 3 ? upgrade3[upgradePrefab3.upgradeTime - 1] : -1;
        upgradeBool3 = false;

    }

    public void updateCost4()
    {
        costUpgrade4 = upgradePrefab4.upgradeTime <= 3 ? upgrade4[upgradePrefab4.upgradeTime - 1] : -1;
        upgradeBool4 = false;

    }

    public void updateCost5()
    {
        costUpgrade5 = upgradePrefab5.upgradeTime <= 3 ? upgrade5[upgradePrefab5.upgradeTime - 1] : -1;
        upgradeBool5 = false;

    }

    public void updateCost6()
    {
        costUpgrade6 = upgradePrefab6.upgradeTime <= 3 ? upgrade6[upgradePrefab6.upgradeTime - 1] : -1;
        upgradeBool6 = false;

    }

    public void updateCost7()
    {
        costUpgrade7 = upgradePrefab7.upgradeTime <= 3 ? upgrade7[upgradePrefab7.upgradeTime - 1] : -1;
        upgradeBool7 = false;

    }

    public void updateCost8()
    {
        costUpgrade8 = upgradePrefab8.upgradeTime <= 3 ? upgrade8[upgradePrefab8.upgradeTime - 1] : -1;
        upgradeBool8 = false;

    }

}
