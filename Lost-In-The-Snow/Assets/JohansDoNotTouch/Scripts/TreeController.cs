using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeController : MonoBehaviour, IAttackeble {
    int index;
    bool isChoppeble = false;
    int amountToDrop;
    TreeInstance treeInstance;


    void Awake()
    {
        gameObject.AddComponent<NavMeshObstacle>();
    }
    public void onAttack()
    {
        if (isChoppeble)
        {
            GetComponentInParent<ForestController>().RemoveOnIndex(index);
            Destroy(gameObject);
        }
    }
    public int Index
    {
        set
        {
            index = value;
        }
    }
    public bool IsChoppeble
    {
        set
        {
            isChoppeble = value;
        }
    }
    public TreeInstance TreeInstance
    {
        set
        {
            treeInstance = value;
        }
    }
    public int AmountToDrop
    {
        set
        {
            amountToDrop = value;
        }
        get
        {
            return amountToDrop;
        }
    }
}
