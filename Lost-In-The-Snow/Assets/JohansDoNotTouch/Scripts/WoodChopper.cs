using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChopper : MonoBehaviour, IAttackeble  {
    int myIndex;
    public int index
    {
        set
        {
            myIndex = value;
        }
    }
    public void onAttack()
    {
        Debug.Log(myIndex);
        GetComponentInParent<ForestController>().RemoveOnIndex(myIndex);
        Destroy(gameObject);
    }
}
