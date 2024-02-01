using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;


    private Queue<string> sentencesQueue;

    void Start()
    {
        sentencesQueue = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentencesQueue.Clear(); //make sure there are no other sentences from old dialogues

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);        //since queues are FIFO, first one we get from array of sentences from dialogue will be out first
        }

        DisplayNextSentence();
    }

    //note we call this function from above and can from any other source, such as a continue button to dequeue the next sentence
    public void DisplayNextSentence()
    {
        if (sentencesQueue.Count == 0)   //if que empty we know dialogue empty, we know its not empty first since we make sure to enqueue beforehand
        {
            EndDialogue();
            return;
        }

        string singleSentence = sentencesQueue.Dequeue(); //this releases one sentence string and we save it so we can display it one at a time
        //Debug.Log(singleSentence);
        dialogueText.text = singleSentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");
    }
}
