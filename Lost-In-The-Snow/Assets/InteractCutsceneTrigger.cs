using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InteractCutsceneTrigger : MonoBehaviour, IInteractible
{
    [SerializeField]
    private GameObject cutsceneToTrigger = null;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool disableCamera, disableMovement, disableInteract;

    public void AlternateInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        Camera.main.gameObject.GetComponent<CameraController>().CutsceneLock = true;
        player.GetComponent<CharacterMovement>().CutsceneLock = true;
        GameObject temp = Instantiate(cutsceneToTrigger);
        temp.transform.position = player.transform.position;
        temp.transform.rotation = player.transform.rotation;
        player.transform.parent = temp.transform;
        temp.SetActive(true);
    }
}
