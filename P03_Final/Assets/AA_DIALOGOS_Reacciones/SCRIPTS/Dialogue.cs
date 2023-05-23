using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "DialogueSystem/Dialogue")]
public class Dialogue : ScriptableObject //per saber amb qui parlem, es mostrara el dialeg
{
    public string Name;
    public DialogueNode StartNode;
}
