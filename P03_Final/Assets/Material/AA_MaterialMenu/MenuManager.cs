using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Show()
    {
        _animator.SetBool("ShowMenu", true);
    }

    public void Hide()
    {
        _animator.SetBool("ShowMenu", false);
    }
}