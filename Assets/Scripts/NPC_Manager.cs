using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{

    //States ide, talking, arguing, sit, walking

    public int state;

    //Components

    Animator anim;

    //Path way
    int curPath;
    public Transform[] path;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(timer());

        
    }

    // Update is called once per frame
    void Update()
    {

        

        // state 4 is walking
        if (state == 4)
        {
            float Distance = Vector3.Distance(transform.position, path[curPath].position);
            transform.position = Vector3.MoveTowards(transform.position , path[curPath].position , 2.5F * Time.deltaTime) ;

            if (Distance < 1)
            {
                if (curPath == path.Length - 1)
                {
                    curPath = 0;
                }
                else
                {
                    curPath++;
                }
            }

            LookPath();

        }
        else
        {
            
           // 
        }
    }

    void LookPath()
    {
        Vector3 dirLook = path[curPath].position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3 (dirLook.x , 0 , dirLook.z));
    }

    IEnumerator timer()
    {
        float ran = Random.Range(0.5f, 1);
        yield return new WaitForSeconds(ran);
        anim.SetInteger("State", state);

    }
}
