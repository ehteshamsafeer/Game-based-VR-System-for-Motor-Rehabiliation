using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;

public class HandyTagManager : MonoBehaviour
{
    [HideInInspector] public int score;
    ChickenSystem chickenSystem;
    [HideInInspector] public int killLeft;
    public TMP_Text leftChickenNum;
    void Start()
    { 
        killLeft = 0;
        chickenSystem = GetComponent<ChickenSystem>();
        int score = 0;
    }
    void Update()
    {
        killLeft = chickenSystem.ChickenCount - score;
        if (killLeft < 1)
        {
            leftChickenNum.text = "Exit from Portal";
        }
        else
        {
            leftChickenNum.text = "Chicken Meat Left: " + killLeft;
            Debug.Log(killLeft);
        }
        
        
    }
   
}
