using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //this makes it editable in the unity editor
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;


}
