using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;


    private Queue<string> sentencesQueue;

    private string sideToOpen;

    private bool isADialogueRunning = false; //mutex to keep dialogues seperate

    // Queue to store dialogues if they are called while another dialogue is running
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();
    private Queue<string> sideToOpenQueue = new Queue<string>(); //note needs both to start the startDialogueCoroutine

    void Start()
    {
        sentencesQueue = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue, string pSideToOpen)
    {

        // If no dialogue is running, start the coroutine immediately
        if (!isADialogueRunning)
        {
            isADialogueRunning = true; ////mutex to later enqueue the dialogues if more want to run
            StartCoroutine(StartDialogueCoroutine(dialogue, pSideToOpen));
        }
        else //if dialogue is running then enqueue 
        {
            // Otherwise, enqueue the dialogue and sideToOpen parameters
            dialogueQueue.Enqueue(dialogue);
            sideToOpenQueue.Enqueue(pSideToOpen);

        }
    }

    IEnumerator StartDialogueCoroutine(Dialogue dialogue, string pSideToOpen)
    {

        //set animation to appear
        sideToOpen = pSideToOpen;
        animator.SetBool(sideToOpen, true);

        //set npc name and empty dialogue text empty
        nameText.text = dialogue.name;
        dialogueText.text = "";

        sentencesQueue.Clear(); //make sure there are no other sentences from old dialogues

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);        //since queues are FIFO, first one we get from array of sentences from dialogue will be out first
        }

        yield return new WaitForSeconds(1); // Wait for 1 second
        Time.timeScale = 0f;                //pause game

        DisplayNextSentence();              //display first sentence
    }

    //note we call this function from above and can from any other source, such as a continue button to dequeue the next sentence
    public void DisplayNextSentence()
    {
        if (sentencesQueue.Count == 0)   //if queue empty we know dialogue empty, we know its not empty first since we make sure to enqueue beforehand
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQueue.Dequeue(); //this releases one sentence string and we save it so we can display it one at a time
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
        //animation to hide and unpause the game
        animator.SetBool(sideToOpen, false);
        Time.timeScale = 1f;




        //if there is other dialogues in queue we need to run by starting them

        if (dialogueQueue.Count > 0) //there is at least one dialogue waiting to load
        {
            Dialogue nextDialogue = dialogueQueue.Dequeue();    //retrieve dialogue from queue of dialogues
            string nextSideToOpen = sideToOpenQueue.Dequeue();  //get animation with that dialogue

            isADialogueRunning = true;
            StartCoroutine(StartDialogueCoroutine(nextDialogue, nextSideToOpen));
        } else
        {
            isADialogueRunning = false;
        }

    }
}
