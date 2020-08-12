using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public Transform cameraHolder; //do którego obiektu ma być "przyczepiona" kamera

    public Vector3 holderDistance; // dystans na jaki ma "trzymać się" danego obiektu

    public float cameraRotationSpeed;

    public bool attached; // czy kamera ma trzymać się gracza

    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        if (!attached)
        {
            holderDistance = cameraHolder.position - transform.position;
        }
        pivot.transform.position = cameraHolder.transform.position;

        //pivot.transform.parent = cameraHolder.transform;
        pivot.transform.parent = null;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        pivot.transform.position = cameraHolder.transform.position;

        float horizontalInput = Input.GetAxisRaw("Mouse X") * cameraRotationSpeed;
        pivot.Rotate(0, horizontalInput, 0);

        //float verticalInput = Input.GetAxis("Mouse Y") * cameraRotationSpeed;
        //pivot.Rotate(-verticalInput, 0, 0);

        float yAngles = pivot.eulerAngles.y;
        //float xAngles = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(0, yAngles, 0);

        transform.position = cameraHolder.position - (rotation * holderDistance);
        transform.LookAt(cameraHolder.transform);
    }
}
