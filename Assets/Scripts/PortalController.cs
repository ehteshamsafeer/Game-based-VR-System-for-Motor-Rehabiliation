using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    HandyTagManager handTagManager;
    void Start()
    {
        GameObject Manager = GameObject.Find("HandyTagManager");
        handTagManager = Manager.GetComponent<HandyTagManager>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if (handTagManager.killLeft < 1)
            {
                SceneManager.LoadSceneAsync("Home");
            }
        }
    }
}
