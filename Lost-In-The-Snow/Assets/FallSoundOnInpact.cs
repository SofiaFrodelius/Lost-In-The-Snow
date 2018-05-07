using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSoundOnInpact : MonoBehaviour {
    [SerializeField] private float distanceToPlaySound;
    CharacterController cc;
    bool allowedToPlay = false;
    [Tooltip("If downwardsspeeds exceeds this value a land-sound will be played on land")]
    [SerializeField] private float minFallSped;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update () {
        Debug.Log(cc.velocity.y);
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, Vector3.down);
        {
            if (Physics.Raycast(ray, out hit, distanceToPlaySound))
            {
         //       Debug.Log(hit);
            }
            else
            {
                allowedToPlay = true;
            }
        }
    }
    bool ShouldPlayLandSound()
    {
        if (cc.velocity.y < minFallSped && allowedToPlay)
        {

            allowedToPlay = false;
        }
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
