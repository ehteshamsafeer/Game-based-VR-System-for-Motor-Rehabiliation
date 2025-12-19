using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHapticFeedback : MonoBehaviour
{
    public XRBaseController leftController; 
    public XRBaseController rightController;

    public void TriggerHapticFeedback(float amplitude, float duration, bool isLeftHand)
    {
        XRBaseController controller = isLeftHand ? leftController : rightController;

        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
            Debug.Log($"Haptic feedback sent to {(isLeftHand ? "left" : "right")} controller.");
        }
        else
        {
            Debug.LogWarning("Controller is not assigned.");
        }
    }
}

