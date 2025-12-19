using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorLimit : MonoBehaviour 
{ 

    public Transform xrController;
    public bool lockXRotation = true;
    public bool lockYRotation = false;
    public bool lockZRotation = true;

    void Update()
    {
        if (xrController)
        {
            Quaternion controllerRotation = xrController.rotation;
            Vector3 eulerRotation = controllerRotation.eulerAngles;

            if (lockXRotation) eulerRotation.x = 0;
            if (lockYRotation) eulerRotation.y = 0;
            if (lockZRotation) eulerRotation.z = 0;

            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}

