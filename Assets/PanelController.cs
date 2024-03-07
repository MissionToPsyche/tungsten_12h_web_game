using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for UI event handling

public class PanelController : MonoBehaviour, IPointerClickHandler
{
    private static float frontmostZ = 0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Panel clicked: " + gameObject.name);
        BringToFront(this.gameObject);
    }

    public void BringToFront(GameObject panel)
    {
        Vector3 newPosition = panel.transform.localPosition;
        newPosition.z = frontmostZ - 1; // Ensure this panel is always brought to the front
        panel.transform.localPosition = newPosition;
        frontmostZ = newPosition.z;
    }
}