using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FallLimitMechanism : MonoBehaviour
{
    [SerializeField] GameObject xrOrigin;

    private void OnTriggerEnter(Collider other)
    {
        PlayerDead();
    }
    void PlayerDead()
    {
        SceneManager.LoadScene("Home");
        Destroy(xrOrigin);

    }
}
