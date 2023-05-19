//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MenuTrigger : MonoBehaviour
//{
//    public Dialog Dialog;
//    private void OnTriggerEnter()//tengo que definir el trigger, aunque ahora mismo no se como definirlo
//    {
//        DialogManage.Instance.StartDialog(Dialog, gameObject);
//    }


//    ///////////////
//    ///

//    public static DialogManage Instance;
//    private Animator _animator;

//    public TextMeshProUGUI Name;
//    public TextMeshProUGUI Speech;
//    public TextMeshProUGUI[] Options;

//    private DialogNode _currentNode;
//    private GameObject talker;

//    void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(this);
//        }
//    }

//    private void Start()
//    {
//        _animator = GetComponent<Animator>();

//    }

//    public void StartDialog(Dialog dialog, GameObject _talker)
//    {
//        talker = _talker;

//        Name.text = dialog.Name;
//        SetNode(dialog.StartNode);
//        Show();
//    }

//    public void OptionChosen(int number)
//    {
//        DialogNode nextNode = _currentNode.Options[number].NextNode;

//        //DialogNode nextNode = _currentNode.Options[number].NextNode;
//        if (nextNode is EndNode)
//        {
//            EndNode endNode = nextNode as EndNode;
//            endNode.EndAction(talker);
//            Hide();
//        }
//        else
//        {

//            SetNode(nextNode);
//        }
//    }

//    private void SetNode(DialogNode node)
//    {
//        _currentNode = node;
//        Speech.text = node.Speech;

//        //este bucle es para que se produzcan de forma automatica tantos botones
//        //como opciones hay, y ahorrarnos botones inutiles o tener que hacerlo
//        //de forma manual
//        for (int i = 0; i < Options.Length; i++)
//        {
//            if (i < node.Options.Count)
//            {
//                Options[i].transform.parent.gameObject.SetActive(true); //si estas dentro de la lista te activas
//                Options[i].text = node.Options[i].Text;
//            }
//            else
//            {
//                Options[i].transform.parent.gameObject.SetActive(false); //si no, no te activas
//            }
//        }
//    }

//    public void Show()
//    {
//        _animator.SetBool("Show", true);
//    }

//    public void Hide()
//    {
//        _animator.SetBool("Show", false);
//    }
//}
