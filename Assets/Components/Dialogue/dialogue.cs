using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //this makes it editable in the unity editor
public class Dialogue
{

    //this object will simply contain information on the NPCs and what they must say, this information is editable once you instantiate it 
    //in another object such as "dialogueTrigger"
    public string name;

    [TextArea(3,10)]
    public string[] sentences;


}
