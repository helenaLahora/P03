using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialog", menuName = "DialogSystem/Dialog")]
public class Dialog : ScriptableObject
{
    public string Name;
    public DialogNode StartNode;
}
