using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LuminaController : MonoBehaviour
{

    Transform target;

    public Transform s;

    NavMeshAgent nva;

    Animator anim;

    bool followingTarget;

   [HideInInspector] public bool m_key = false;

    // Start is called befor e the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = target.GetComponent<Animator>();
        nva = target.GetComponent<NavMeshAgent>();
       // setDestiny();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetButtonDown("Fire1"))
        {
            setDestiny();
        }

        if (Vector3.Distance(target.position , s.position) > 0.5f)
        {
            nva.isStopped = false;
            nva.SetDestination(s.position);
            anim.SetInteger("State" , 4);
        }
        else
        {
            nva.isStopped = true;
            anim.SetInteger("State", 0);
        }


       LookTarget();

        if (followingTarget)
        {
            transform.position = Vector3.Lerp(transform.position , new Vector3 (target.position.x -5 , transform.position.y , transform.position.z), 10 * Time.deltaTime);
        }

        selection();

        s.position = new Vector3(s.position.x, 0, s.position.z);

    }

    private void FixedUpdate()
    {
        
    }


    void LookTarget()
    {
        Vector3 LookDir = s.position - target.position;
        target.rotation = Quaternion.LookRotation(new Vector3(LookDir.x , 0 , LookDir.z));
    }
    void setDestiny()
    { 

        RaycastHit hit;
        Ray ray;

         ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray , out hit ))
        {

            if (hit.transform.GetComponent<Building>())
            {
                s.position = hit.transform.GetComponent<Building>().door.position;
            }
            else
            {
                s.position = hit.point;
            }

           
            StartCoroutine(smoothCameraMovement());

            

        }

    }

    void selection()
    {
        RaycastHit hit;
        Ray ray;

        ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<Building>())
            {
                hit.transform.GetComponent<Building>().selected = true;
                m_key = true;
            }
            else
            {
                m_key = false;
            }
        }
        

    }

    IEnumerator smoothCameraMovement()
    {
        followingTarget = false;
        yield return new WaitForSeconds(0.25f);
        followingTarget = true;
        StopAllCoroutines();
    }

}
