using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieShooter : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] Transform zombieTransform;
    private ZombieController zombieScript;
    [SerializeField] TMP_Text scoreText;
    int score;
    [SerializeField] ParticleSystem zombieSpawnEffects;
    AudioSource spawnSound;

    void Start()
    {
        RenderSettings.ambientLight = Color.white;
        DynamicGI.UpdateEnvironment();
        spawnSound = GetComponent<AudioSource>();
        score = 0;
        GameObject zombie = GameObject.FindWithTag("Zombie");
        if (zombie == null)
        {
            SpawnZombie();
        }
        
    }
    void Update()
    {
        scoreText.text = score.ToString();

        if (zombieScript.isDead == true)
        {
            score += 1;
            SpawnZombie();
        }
        
        
    }
    void SpawnZombie()
    {
        spawnSound.Play();
        zombieSpawnEffects.Play();
        GameObject zombieInstance = Instantiate(zombiePrefab, zombieTransform.position, zombieTransform.rotation);
        zombieScript = zombieInstance.GetComponent<ZombieController>();
    }
}
