using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHand : MonoBehaviour
{
    public Transform anchor;
    public Transform Hand;
    public float x;
    public float y;
    public float z;

    void Update()
    {
        transform.rotation = new Quaternion(Hand.transform.rotation.x, Hand.transform.rotation.y, -Hand.transform.rotation.z, 1);
    }
}

