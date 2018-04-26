using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour, IUsable
{

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Use(ItemHand ih)
    {
        SwingAxe();
    }
    void SwingAxe()
    {

    }
}
