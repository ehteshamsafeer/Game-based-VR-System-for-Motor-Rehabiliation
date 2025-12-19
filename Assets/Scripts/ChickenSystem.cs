using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.Examples;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ChickenSystem : MonoBehaviour
{

    public GameObject ChickensTransformParent;
    public GameObject ChickenObject;
    List<GameObject> Chickens = new List<GameObject>();
    public int ChickenCount;


    public string difficultyLevel;
    void Start()
    {
        difficultyLevel = PlayerPrefs.GetString("Game Level");
        if (difficultyLevel == "Easy") { ChickenCount = 6; }
        else if (difficultyLevel == "Medium") {ChickenCount = 10;}
        else if (difficultyLevel == "Hard") {ChickenCount = 15;}

        List<int> temp = new List<int>();
        ChickensTransformParent.GetChildGameObjects(Chickens);
        for (int i = 0; i < ChickenCount; i++)
        {
            int rand_num = UnityEngine.Random.Range(0, Chickens.Count);
            if (!temp.Contains(rand_num))
            {
                Instantiate(ChickenObject, Chickens[rand_num].transform);
                temp.Add(rand_num);
            }
            else
            {
                i--;
            }
                
            
        }
    }

}
