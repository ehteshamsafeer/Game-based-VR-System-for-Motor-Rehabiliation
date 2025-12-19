using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EMGShootMechanics : MonoBehaviour
{
    BiofeedbackConnection biofeedbackScript;
    [SerializeField] PistolMechanics pistolMechanicsScript;
    [SerializeField] Slider sensorRate;
    void Start()
    {
        GameObject homeManager = GameObject.FindWithTag("Home");
        biofeedbackScript = homeManager.GetComponent<BiofeedbackConnection>();
    }

    void Update()
    {
        sensorRate.value = biofeedbackScript.ShareEMGValues();
        if (sensorRate.value > 700)
        {
            pistolMechanicsScript.PistolShoot();
        }
    }
}
