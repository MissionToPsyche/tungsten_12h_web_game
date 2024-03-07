using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCloseCanvas : MonoBehaviour
{

    //we have the ability to drag a canvas onto THIS SCRIPT
    [SerializeField] private GameObject canvas;

    public void openPanel()
    {
        //whatever canvas we dragged into the script will close/open 
        canvas.SetActive(true);
       
    }

    public void closePanel()
    {
        canvas.SetActive(false);
    }

}
