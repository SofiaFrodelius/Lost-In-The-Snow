using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour, IUsable
{
    bool InspectBool = false;
    bool TreeChopBool = false;
    [SerializeField] private GameObject chopParticles;
    [SerializeField] private Transform particlePos;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Use(ItemHand ih)
    {
        SwingAxe();
    }
    void SwingAxe()
    {
        anim.SetBool("TreeChopBool", true);
        
        
    }
    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("TreeChop"))
        {
            anim.SetBool("TreeChopBool", false);
        }
    }
    public void AxeHit()
    {
        Debug.Log("Instansierar partikelsystem");
        Instantiate(chopParticles, particlePos);
    }
}
