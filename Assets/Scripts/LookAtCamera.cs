using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        Vector3 direction = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);


    }
}
