using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emilroterahund : MonoBehaviour
{


	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            //float angle = Vector3.Angle(Vector3.up, hit.normal);
            //transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);

            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));


        }
    }
}
