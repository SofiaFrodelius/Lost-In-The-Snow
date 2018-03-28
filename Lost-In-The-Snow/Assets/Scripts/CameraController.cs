using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1.0f;
    private Vector2 look = Vector2.zero;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        move *= sensitivity;
        look += move;
        look.y = Mathf.Clamp(look.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-look.y, Vector3.right);
        transform.parent.transform.localRotation = Quaternion.AngleAxis(look.x, transform.parent.transform.up);

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
