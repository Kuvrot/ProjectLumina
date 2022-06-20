using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RaceManager : MonoBehaviour
{

    public GameObject[] comp;
    public float[] distances;
    public GameObject[] positions;

    public Transform goal;


    // Start is called before the first frame update
    void Start()
    {
        positions = comp;
    }

    // Update is called once per frame
    void Update()
    {
        
   

    }
}
