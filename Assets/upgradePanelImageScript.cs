using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradePanelImageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.localPosition = new Vector3(6,3,0);

        gameObject.SetActive(false);        //as soon as panel starts set it false to hide and get the upgrade initialized
    }

}
