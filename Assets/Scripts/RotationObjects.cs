using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjects : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(0, speed, 0 * Time.deltaTime);
    }
}
