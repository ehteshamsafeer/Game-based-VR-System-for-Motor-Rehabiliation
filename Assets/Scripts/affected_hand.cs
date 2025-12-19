using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class affected_hand : MonoBehaviour
{
    public XRBaseController LeftController;

    public float intensity = 0.5f;
    public float duration = 0.2f;
    public GameObject RightHand;

    void Update()
    {
        transform.rotation = new Quaternion(RightHand.transform.rotation.x,RightHand.transform.rotation.y,-RightHand.transform.rotation.z,1);
        transform.position = RightHand.transform.position + new Vector3(-0.278f,0,0) ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        SendHaptics();
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");
    }
    [ContextMenu("SendHaptics")]
    void SendHaptics()
    {
        LeftController.SendHapticImpulse(intensity, duration);
    }

}
