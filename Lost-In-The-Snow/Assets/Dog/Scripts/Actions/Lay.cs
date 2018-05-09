using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lay : DogAction
{
    DogTimer timer;
    public Lay(Dog d, float time) : base(d)
    {
        timer = new DogTimer(time);
    }
    public override void StartAction()
    {
        actionTimer = actionDelay;
        timer.ResetTimer();
        isDone = false;
        animator.SetBool("Lay", true);
    }
    public override void UpdateAction()
    {
        if (animator.GetBool("Lay") && animator.GetCurrentAnimatorStateInfo(0).IsName("LayIdle"))
        {
            animator.SetBool("Lay", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("LayIdle"))
        {
            if (!isDone)
            {
                if (!timer.IsDone())
                {
                    timer.AddTime(Time.deltaTime);
                }
                else
                {
                    isDone = true;
                    animator.SetTrigger("StandUp");

                }
            }
        }
    }
    public override void EndAction()
    {
        animator.SetBool("Lay", false);
        dog.AddEffectToMood(moodEffect);
    }

}
