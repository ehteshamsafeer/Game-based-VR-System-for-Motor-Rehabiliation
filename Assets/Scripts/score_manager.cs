using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class score_manager : MonoBehaviour
{
    public GameObject collectables;
    public GameObject XR_interaction;
    public GameObject Hands;
    public int scorepoint=4;
    public TMP_Text textbox;
    private Vector3 startposition = new Vector3(6.62476964e-07f, 0.0318626165f, 36.9900017f);
    public AudioSource collision_sound;

    void Start()
    {
        textbox.text = scorepoint.ToString();
        SceneCheck();
        
    }

    void Update()
    {   
        
        textbox.text = Mathf.Round(scorepoint).ToString();
        if (transform.position.y < 8)
        {

            SceneManager.LoadSceneAsync(3);
            transform.position = startposition;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coin")
        {
            scorepoint -= 1;
            collision_sound.Play();
            Destroy(other.gameObject);
        }
    }

    public void GameOver()
    {
        if (scorepoint < 1)
        {
            SceneManager.LoadScene(2);
        } 
    }
    public void SceneCheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {   
            transform.position = new Vector3(0, 0.114500165f, 36.9900017f);
        }
    }
}
