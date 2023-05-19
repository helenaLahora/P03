using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newEndNode", menuName = "DialogSystem/EndNode")]

public class EndNode : DialogNode
{
    public void EndAction(GameObject talker)
    {
        talker.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("This is the end, my onley friend, the end");
    }
}
