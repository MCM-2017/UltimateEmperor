using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform camera;
    void LateUpdate()
    {
        this.transform.LookAt(transform.position + camera.forward);
    }
}
