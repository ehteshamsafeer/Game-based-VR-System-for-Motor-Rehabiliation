using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolMechanics : MonoBehaviour
{

    public Transform bulletfirepoint;
    public GameObject bullet;
    public InputActionProperty triggerButton;
    public XRBaseController controller;


    public Transform shootPoint;
    [SerializeField] Animator gunAnimator;
    [Range(0, 1)]
    public float disperseBullet;
    AudioSource shootSound;

    bool canFire;
  

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
        canFire = true;
    }
    private void Update()
    {
        float triggerValue = triggerButton.action.ReadValue<float>();
        if (triggerValue > 0.8 && canFire)
        {
            PistolShoot();
        }
        else if (triggerValue < 0.2)
        {
            canFire = true;
            
        }
        
    }

    void FireBullet()
    {
        gunAnimator.SetTrigger("IsShooting");
        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * 2000 + new Vector3(Random.Range(disperseBullet, -disperseBullet), Random.Range(disperseBullet, -disperseBullet), 0) * 100);
    }
    public void TriggerHapticFeedback(float amplitude, float duration)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
        else
        {
            Debug.LogWarning("Controller is not assigned.");
        }
    }
    public void PistolShoot()
    {
        shootSound.Play();
            TriggerHapticFeedback(0.6f, 0.3f);
            FireBullet();
            canFire = false;
    }



}

