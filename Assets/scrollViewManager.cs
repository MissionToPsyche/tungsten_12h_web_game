using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scrollViewManager : MonoBehaviour
{
    private VerticalLayoutGroup verticalLayoutGroup;
    private ContentSizeFitter contentSizeFitter;

    private void Start()
    {
        // Access the VerticalLayoutGroup component
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();

        // Access the ContentSizeFitter component
        contentSizeFitter = GetComponent<ContentSizeFitter>();
    }

    private void Update()
    {
        // Force the layout to be rebuilt
        LayoutRebuilder.ForceRebuildLayoutImmediate(verticalLayoutGroup.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentSizeFitter.GetComponent<RectTransform>());
    }
}
