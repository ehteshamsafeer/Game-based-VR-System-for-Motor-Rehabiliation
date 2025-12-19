 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowExerciseController : MonoBehaviour
{
    public GameObject RightController;
    PistolMechanics PMInstance;

    private void Start(){
        PMInstance = RightController.GetComponent<PistolMechanics>();
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Something is collding with Elbow destined collider.");
            PMInstance.PistolShoot();

        }
        
    }
}
