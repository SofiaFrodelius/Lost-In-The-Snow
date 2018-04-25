using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    TutorialUI tutorialUI;
    [SerializeField]
    private string[] tutorialTexts;
    private int activeTutorial = 99999;

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
        activeTutorial = tutorialID;
        switch(tutorialID)
        {
            case 0:

                //tutorial 2 starting
                break;

            case 1:
                //tutorial 2 starting
                break;
            case 2:
                //tutorial 2 starting


                break;
        }


    }



    public void finishTutorial(int tutorialID)
    {
        if (!tutorialFinished[tutorialID] && activeTutorial == tutorialID)
        {
            tutorialFinished[tutorialID] = true;
            tutorialUI.setTutorial("");

            switch(tutorialID)
            {
                case 0:
                    //Tutorial 0 finished
                    break;
                case 1:
                    //tutorial 1 finished
                    break;
                case 2:
                    //tutorial 2 finished
                    break;
            }


        }
    }

}
