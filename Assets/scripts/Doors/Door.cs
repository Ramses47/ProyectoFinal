using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOpen;
    private Animator animator;
    private AudioSource doorAS;

    void Start()
    {
        animator= GetComponent<Animator>();
        doorAS = GetComponent<AudioSource>();
        isOpen=true;
        UpdateAnimation();
    }
    
    public void SetIsOpen(bool _state)
    {
        isOpen = _state;
        doorAS.Play();
        UpdateAnimation();
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    void UpdateAnimation()
    {
        animator.SetBool("IsOpen", isOpen);
    }
}
