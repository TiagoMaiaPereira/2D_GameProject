using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName ="ScriptableObjects/Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    public string charName;

    [TextArea(1, 2)]
    public string[] sentences;
}
