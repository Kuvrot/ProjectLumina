using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayerController : MonoBehaviour
{
    public int place;
    public float speed = 8 , rotSpeed = 16;
    float V_vel;

    float h;
    float v;

    RaceCamera rcam;

    // Start is called before the first frame update
    void Start()
    {
        rcam = Camera.main.GetComponent<RaceCamera>();   
    }

    // Update is called once per frame
    void Update()
    {


       
         if (Input.GetAxis("Vertical") != 0)
        {       
           
                V_vel = speed;
               
        }

        v = Input.GetAxis("Vertical") * V_vel * Time.deltaTime;

        // v = Input.GetAxis("Vertical") * V_vel * Time.deltaTime;
        h = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        transform.Translate(0, 0, v);
        transform.Rotate(0, h, 0);
       
        

    }
}
