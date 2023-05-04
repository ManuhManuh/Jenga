using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float orbitSpeed = 500.0f;
    [SerializeField] private float orbitDistance = 2.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("Mouse input correct");
            RotateCamera();
        }
    }

    private void RotateCamera()
    {
        if(Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log("Inputs are not zero");
            float horizontalMovement = Input.GetAxis("Mouse X") * orbitSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, horizontalMovement, Space.World);
        }
    }

    private void ChangeFocalPoint(GameObject newFocalPoint)
    {
        // make the camera a child of the new focal point
        transform.SetParent(newFocalPoint.transform);

        // position it at the orbit distance away from the new focal point
        Vector3 orbitPosition = new Vector3(newFocalPoint.transform.position.x, newFocalPoint.transform.position.y, newFocalPoint.transform.position.z - orbitDistance);
        transform.position = orbitPosition;
    }
}
