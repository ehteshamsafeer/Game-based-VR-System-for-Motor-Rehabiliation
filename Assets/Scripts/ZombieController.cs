using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    
    [SerializeField] PuppetMaster puppetMaster;
    public float health;
    [SerializeField] private Slider healthBar;
    private NavMeshAgent zombieAI;
    GameObject player;
    public bool isDead;
    AudioSource audioSource;
    public string difficultyLevel;
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        zombieAI = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        health = 100;
        isDead = false;


        difficultyLevel = PlayerPrefs.GetString("Game Level");
        if (difficultyLevel == "Easy") { zombieAI.speed = 0.35f;}
        else if (difficultyLevel == "Medium") { zombieAI.speed = 0.7f;}
        else if (difficultyLevel == "Hard") { zombieAI.speed = 1f;}
    }
    void Update()
    {
        healthBar.value = health;
        zombieAI.SetDestination(player.transform.position);

        if (health < 1)
        {
            ZombieisDeadNow();
        }

    }
    void ZombieisDeadNow()
    {
        isDead = true;
        if (puppetMaster != null)
        {
            puppetMaster.state = PuppetMaster.State.Dead;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
        zombieAI.Stop();
        Invoke("RemoveDeadbody", 3f);
    }
    void RemoveDeadbody()
    {
        Destroy(gameObject);
    }

    }
