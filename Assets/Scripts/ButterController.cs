using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterController : MonoBehaviour
{
    Vector3 target;
    Vector3 currentPos;
    float x;
    float y;
    float z;
    void Start()
    {
        InvokeRepeating("ChangeTarget", 1f, 1f);
    }

    void Update()
    {

    }
    void ChangeTarget()
    {
        x = 0; y = Random.Range(0,360); z = 0;
 
        transform.Rotate(x,y,z * Time.deltaTime * 0.4f);
    }



}
