using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private Animator _animator;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public TextMeshProUGUI[] Options;

    private DialogueNode _currentNode;

    private GameObject _talker;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject talker)
    {
        _talker = talker;

        Name.text = dialogue.Name;
        SetNode(dialogue.StartNode);
        Show();
    }

    private void SetNode(DialogueNode node)
    {
        _currentNode = node;
        Speech.text = node.Speech;

        for (int i = 0; i < Options.Length; i++)
        {
            if (i < node.Options.Count)
            {
                Options[i].transform.parent.gameObject.SetActive(true);
                Options[i].text = node.Options[i].Text;


            }
            else
            {
                Options[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }


    public void OptionChosen(int number)
    {
        DialogueNode nextNode = _currentNode.Options[number].NextNode;

        SerializedAnimationClip serializedClip = _currentNode.Options[number].animationClip;
        AnimationClip animationClip = serializedClip.clip;

        if (animationClip != null)
        {
            _talker.GetComponent<Animator>().Play(animationClip.name);
        }

        if (nextNode is EndNode)
        {
            EndNode endNode = nextNode as EndNode;
            endNode.EndAction(_talker);

            Hide();
        }
        else
        {
            SetNode(nextNode);
        }
    }


    public void Show()
    {
        _animator.SetBool("Show", true);
    }

    public void Hide()
    {
        _animator.SetBool("Show", false);
    }
}


