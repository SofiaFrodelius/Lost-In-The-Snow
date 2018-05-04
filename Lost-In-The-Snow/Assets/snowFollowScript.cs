using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowFollowScript : MonoBehaviour
{
    private Vector3 previousPos = Vector3.zero;
    private Vector3 moveDelta;
    public GameObject player;
    public int multiplier = 500;
    public void Update()
    {
        moveDelta = player.transform.position - previousPos;

        Debug.Log(moveDelta);
        if(moveDelta == Vector3.zero)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        else transform.position = new Vector3(player.transform.position.x + (moveDelta.x * multiplier), transform.position.y, player.transform.position.z + (moveDelta.z * multiplier));

        previousPos = player.transform.position;
    }
}
