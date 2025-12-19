using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathController : MonoBehaviour
{
    [SerializeField] PuppetMaster PuppetMaster;
    [SerializeField] GameObject zombieObject;
    ZombieController zombieControllerScript;
    void Start()
    {
        zombieControllerScript = zombieObject.GetComponent<ZombieController>();     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            zombieControllerScript.health -= 10;
            if (zombieControllerScript.health < 1)
            {
                PuppetMaster.state = PuppetMaster.State.Dead;
            }
            StartCoroutine(HitEffect(collision.gameObject));
            
        }
    }
    public IEnumerator HitEffect(GameObject fireball)
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(fireball);
    }
}
