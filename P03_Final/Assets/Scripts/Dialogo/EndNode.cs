using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newEndNode", menuName = "DialogueSystem/EndNode")]
public class EndNode : DialogueNode //fiquem d'herencia a dialoguenode pq el endnode tmb es un dialeg
{
    public void EndAction(GameObject talker)
    {
        Debug.Log("Has pagado con 10 puntos de afecto la sabiduría y tiempo de los MOAIS :)");
    }
}
