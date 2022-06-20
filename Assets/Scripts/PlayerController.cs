using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform[] positions;

    public Vector3[] verticalPositions;

    public GameObject Lasers;

    public bool death;

    //Speed when moving sideways
    float sideSpeed = 5;

    //General speed of the player
    public float speed;

    int Direction;
    int VerDir;
    public int state = 1;

    public GameObject impactEffect;

    AudioSource asrce;
    public AudioClip laserShotSFX , playerImpactSFX;

    //Components
    Animator anim;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
       // jumpPos = transform.position;
        verticalPositions[1].y = 6;
        verticalPositions[0].y = transform.position.y;
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        asrce = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

      if (!death)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Lasers.SetActive(true);
                StartCoroutine(lasers());
                Shoot();
            }

            if (Input.GetButtonDown("Right"))
            {
                state++;
                Direction = 1;
                checkState();
            }

            if (Input.GetButtonDown("Left"))
            {

                state--;
                checkState();
                Direction = -1;
            }

            if (Input.GetButtonDown("Jump"))
            {
                VerDir = 1;
                //anim.SetTrigger("Up");
            }

            if (Input.GetButtonDown("Down"))
            {
                VerDir = 0;
            }

            Turn(Direction, VerDir);
        }
        else
        {
            if (!asrce.isPlaying)
            {
                Time.timeScale = 1;
                gm.deathScreen.SetActive(true);
                Destroy(this.gameObject);
            }
        }

       
    }

    void Turn(int dir , int verDir)
    {
        
        transform.position = Vector3.Lerp(transform.position, new Vector3 (positions[state].position.x , verticalPositions[verDir].y, 0), sideSpeed * Time.deltaTime);

        if (transform.position == positions[state].position)
        {
            ///moving = false;
            Direction = 0;
        }

        switch (dir)
        {
            case -1: anim.SetTrigger("Left"); break;
            case 1: anim.SetTrigger("Right"); break;
        }


        Direction = 0;

    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position +  new Vector3 (0.25f,0,0), transform.forward , out hit , 100))
        {
            if (hit.transform.GetComponent<Obstacles>())
                if (hit.transform.GetComponent<Obstacles>().type == 3)
                    hit.transform.GetComponent<Obstacles>().Destruction();

            Instantiate(impactEffect , hit.point , Quaternion.LookRotation(Camera.main.transform.position));
               
            Debug.Log(hit.transform.name);

        }

        Debug.DrawRay(transform.position + new Vector3(0.5f, 0, 0), transform.forward, Color.red, 10);

        if (Physics.Raycast(transform.position + new Vector3(-0.25f, 0, 0), transform.forward, out hit, 100))
        {
            if (hit.transform.GetComponent<Obstacles>())
                if (hit.transform.GetComponent<Obstacles>().type == 3)
                    hit.transform.GetComponent<Obstacles>().Destruction();

            Debug.Log(hit.transform.name);

        }

        Debug.DrawRay(transform.position + new Vector3(-0.5f, 0, 0), transform.forward, Color.red, 10);

        asrce.PlayOneShot(laserShotSFX);

    }

    void checkState()
    {
        if (state > 2)
            state = 2;
        else if (state < 0)
            state = 0;

        //moving = true;
    }
   
    IEnumerator lasers()
    {

        yield return new WaitForSeconds(0.05f);
        Lasers.SetActive(false);
        StopAllCoroutines();
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            asrce.PlayOneShot(playerImpactSFX);
            GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            death = true;
            Time.timeScale = 0.25f;
           


        }
    }
}
