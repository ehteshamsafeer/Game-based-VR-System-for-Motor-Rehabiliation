using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVibration : MonoBehaviour
{
    public float vibrationDuration = 0.3f;
    public float vibrationStrength = 0.8f;

    private bool isTouchingGround = false;
    public XRBaseController leftController;
    public XRBaseController rightController;


    void Update()
    {
        if (transform.position.y < 0)
        {
            leftController.SendHapticImpulse(vibrationStrength,vibrationDuration);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        leftController.SendHapticImpulse(vibrationStrength, vibrationDuration);
    }

}
