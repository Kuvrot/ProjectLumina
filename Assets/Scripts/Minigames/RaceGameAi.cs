using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaceGameAi : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent nva;
    public int place;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        nva = GetComponent<NavMeshAgent>();
        speed = nva.speed;
    }

    // Update is called once per frame
    void Update()
    {
        nva.SetDestination(goal.position);


       
        
    }
}
