using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bonk") 
        {
            DialogueManager.Instance.StartDialogue(Dialogue, gameObject);
        }
    }
}

