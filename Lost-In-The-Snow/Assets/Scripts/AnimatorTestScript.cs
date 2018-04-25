using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTestScript : MonoBehaviour
{
    public int testNumber = 0;

    public void SetTestNumber(int newNumber)
    {
        testNumber = newNumber;
    }

    public void OutputTestNumber()
    {
        Debug.Log(testNumber);
    }
}