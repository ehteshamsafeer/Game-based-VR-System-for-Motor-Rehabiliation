using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerZ : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0.8f;

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Zombie"))
        {
            
            Invoke("StopGame", 1);
        }
    }


    void StopGame()
    {
 
        SceneManager.LoadScene("Home"); 
        Destroy(gameObject);

    }
}
