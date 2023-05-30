using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueNode", menuName = "DialogueSystem/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string Speech;
    public List<DialogueOptions> Options;
}

[System.Serializable]
public class DialogueOptions
{

    public string Text;
    public DialogueNode NextNode;
    public SerializedAnimationClip animationClip;


}

[System.Serializable]
public class SerializedAnimationClip
{
    public AnimationClip clip;

}
