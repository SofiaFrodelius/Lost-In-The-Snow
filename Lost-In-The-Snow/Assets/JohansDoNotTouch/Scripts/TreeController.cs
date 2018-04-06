using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, IAttackeble  {
    int myIndex;
    bool isChoppeble = false;

    public void onAttack()
    {
        if (isChoppeble)
        {
            GetComponentInParent<ForestController>().RemoveOnIndex(myIndex);
            Destroy(gameObject);
        }
    }
    public int index
    {
        set
        {
            myIndex = value;
        }
    }
    public bool choppeble
    {
        set
        {
            isChoppeble = value;
        }
    }
}
