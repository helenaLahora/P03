using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newEndNode", menuName = "DialogueSystem/EndNode")]
public class EndNode : DialogueNode //fiquem d'herencia a dialoguenode pq el endnode tmb es un dialeg
{
    public void EndAction(GameObject talker)
    {
        Debug.Log("Callate la boca tontoelculo");
    }
}
