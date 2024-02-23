using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] string sideToOpen;

    public void triggerDialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue, sideToOpen);
    }

}
