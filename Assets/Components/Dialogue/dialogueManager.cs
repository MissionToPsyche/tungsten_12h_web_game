using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;


    private Queue<string> sentencesQueue;

    private string sideToOpen;

    void Start()
    {
        sentencesQueue = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue, string pSideToOpen)
    {
        sideToOpen = pSideToOpen;

        animator.SetBool(sideToOpen, true);

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

        string sentence = sentencesQueue.Dequeue(); //this releases one sentence string and we save it so we can display it one at a time
        //Debug.Log(singleSentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool(sideToOpen, false);
    }
}
