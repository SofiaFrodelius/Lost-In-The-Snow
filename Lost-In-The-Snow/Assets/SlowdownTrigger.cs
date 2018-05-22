using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTrigger : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;
    [SerializeField]
    private float sprintMultiplier = 1.0f;
    [SerializeField]
    private float timeToSlow = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterMovement cm = other.GetComponent<CharacterMovement>();
            StartCoroutine(slow(cm, timeToSlow));
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


    IEnumerator slow(CharacterMovement cm, float time)
    {
        float elapsedTime = 0.0f;
        float startMoveSpeed = cm.MovementSpeed;
        float startSprintMultiplier = cm.SprintMultiplier;

        while (elapsedTime < time)
        {
            cm.MovementSpeed = Mathf.Lerp(startMoveSpeed, movementSpeed, (elapsedTime / time));
            cm.SprintMultiplier = Mathf.Lerp(startSprintMultiplier, sprintMultiplier, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}