using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    TutorialUI tutorialUI;
    [SerializeField]
    private string[] tutorialTexts;

    public static Tutorial instance;

    private bool[] tutorialFinished;

    public void Awake()
    {
        tutorialFinished = new bool[tutorialTexts.Length];
        tutorialFinished[0] = false;
        if(instance != null)
        {
            Debug.LogWarning("Two or more instances of Tutorial in scene.");
            return;
        }
        instance = this;
    }


    public void Start()
    {
        tutorialUI = TutorialUI.instance;
    }



    public void triggerTutorial(int tutorialID)
    {
        tutorialUI.setTutorial(tutorialTexts[tutorialID]);
    }



    public void finishTutorial(int tutorialID)
    {
        if (!tutorialFinished[tutorialID])
        {
            tutorialFinished[tutorialID] = true;
            tutorialUI.setTutorial("");
        }
    }

}
