using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mx, my, sensitivity = 50, xRot = 0;
    private GameObject pl;
    void Start()
    {
        pl = GameObject.FindWithTag("Player");
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mx = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        //my = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // xRot -= my;
        // xRot = Mathf.Clamp(xRot, -90, 90);
        // transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        pl.transform.Rotate(Vector3.up * mx);
    }
}
