using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{

    static public GameObject playerCamera;
    static public GameObject player;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
