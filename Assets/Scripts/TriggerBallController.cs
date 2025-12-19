using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TriggerBallController : MonoBehaviour
{
    public float range;
    public float moveSpeed;
    private Vector3 targetPosition;
    public SkinnedMeshRenderer butterlyRenderer;
    ParticleSystem FiretoZombie;
    public AudioClip fireSound;
    AudioSource zombieSoundSource;
    GameObject Zombie;

    int hardlevel;
    int easylevel;
    int normallevel;
    void Start()
    {
        
        easylevel = 20; normallevel = 10; hardlevel = 5;
        
        SetRandomTargetPosition();
    }
     
    void Update()
    {
        
        MoveTowardsTarget();
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        targetPosition = new Vector3(Random.Range(-range, range),Random.Range(-range, range));
    }

    void MoveTowardsTarget()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerStay(Collider other)
    {
        Zombie = GameObject.FindWithTag("Zombie");
        ZombieController zombieScript = Zombie.GetComponent<ZombieController>();
        FiretoZombie = Zombie.GetComponentInChildren<ParticleSystem>(true);
        zombieSoundSource = Zombie.GetComponent<AudioSource>();
        if (other.CompareTag("PlayerHand"))
        {
            SkinnedMeshRenderer handRenderer = other.GetComponent<SkinnedMeshRenderer>();
            handRenderer.material.color = Color.yellow;
            handRenderer.material.EnableKeyword("_EMISSION");
            zombieScript.health -= Time.deltaTime * easylevel;
            if (!zombieSoundSource.isPlaying)
            {
                zombieSoundSource.PlayOneShot(fireSound);
            }
       
            Debug.Log(zombieScript.health);
            if (!FiretoZombie.isPlaying)
            {
                FiretoZombie.Play();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            FiretoZombie.Stop();
            SkinnedMeshRenderer handRenderer = other.GetComponent<SkinnedMeshRenderer>();
            handRenderer.material.color = Color.white;
            handRenderer.material.DisableKeyword("_EMISSION");
            zombieSoundSource.Stop();

        }

    }
}
