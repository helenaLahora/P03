using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog Dialog;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bonk")
        {
            DialogManage.Instance.StartDialog(Dialog, gameObject);
        }
    }
}
