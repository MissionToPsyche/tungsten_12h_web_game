using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject canvas;
    //[SerializeField] private GameObject canvas;



    public void openPanel()
    {
        canvas.SetActive(true);
    }

    public void closePanel()
    {
        canvas.SetActive(false);
    }

}
