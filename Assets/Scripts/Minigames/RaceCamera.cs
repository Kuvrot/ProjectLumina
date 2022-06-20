using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCamera : MonoBehaviour
{

    public List <Transform> targets;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
     
        
    
    }

    // Update is called once per frame
    void Update()
    {

       // transform.Translate(0, 0, 10 * Time.deltaTime);



    }

    private void LateUpdate()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = new Vector3 (newPos.x , newPos.y  , newPos.z);
        


    }   

    Vector3 GetCenterPoint()
    {


        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;

    }
}
