using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private int tutorialToTrigger;
    private Tutorial tutorial;

    public void Start()
    {
        tutorial = Tutorial.instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tutorial.triggerTutorial(tutorialToTrigger);
            Destroy(gameObject);
        }
    }

}
