using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomXRSetting : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
