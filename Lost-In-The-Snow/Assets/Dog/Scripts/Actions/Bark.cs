using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Bark : DogAction
{
    public Bark(Dog d) : base(d)
    {
    }
    public override void StartAction()
    {
        isDone = false;
        animator.SetTrigger("Bark");
        GameObject barkEmitter = dog.transform.Find("BarkSoundEmitter").gameObject;
        if (barkEmitter)
        {
            barkEmitter.GetComponent<StudioEventEmitter>().Play();
        }
        else
        {
            Debug.LogWarning("Dog has no GameObject BarkSoundEmitter Child with a fmod_EventStudioEmitter with barkSound");
        }
    }
    public override void UpdateAction()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
            isDone = true;
    }
    public override void EndAction()
    {
        isDone = true;
    }
}
