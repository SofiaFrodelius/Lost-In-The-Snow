using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class VoiceLinePromt : MonoBehaviour {

    StudioEventEmitter em;
    private bool allowedToPlay = true;
    [Tooltip("This value is the minimum time between playtime for this voiceLine")]
    [SerializeField] private float timeToWaitForPlay = 10f;
	// Use this for initialization
	void Start () {
        em = GetComponent<StudioEventEmitter>();

    }

    public void PlayVoiceLine()
    {
        Debug.Log("Tjo");   
        if (em != null && !em.IsPlaying() && allowedToPlay)
        {
            em.Play();
            allowedToPlay = false;
        }
        StartCoroutine(Resetter());
    }
    IEnumerator Resetter()
    {

        yield return new WaitForSeconds(timeToWaitForPlay);

        allowedToPlay = true;
    

    }
}
