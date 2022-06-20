using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public Transform[] positions;
    public GameObject[] obstacles;

    public float spawnRate = 5;

    public float globalObstacleSpeed;

    static public GameObject gameManager;

    public GameObject deathScreen;

    public bool canTurbo = false;
    public bool turbo = false;

    public VolumeProfile profile;

    Vignette vignette;

    //public GameObject turboWarning, normalEngineSound, TurboEngineSound;


    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = this.gameObject;
    }

    void Start()
    {

        profile.TryGet <Vignette> (out vignette);
        
        StartCoroutine(Clock());

        Spawn();


    }

    // Update is called once per frame
    void Update()
    {
        if (globalObstacleSpeed < 100)
            globalObstacleSpeed += 1 * Time.deltaTime/2;
        else
        {
            canTurbo = true;
        }

        if (spawnRate > 0.5f)
            spawnRate -=0.01f * Time.deltaTime / 2;

        /*

        if (Input.GetButtonDown("Interact") && !turbo)
        {
            turbo = true;
        }
        else if (Input.GetButtonDown("Interact") && turbo)
        {
            turbo = false;
        }


        if (canTurbo)
         {
             if (turbo)
             {
                 globalObstacleSpeed = 150;
                 vignette.intensity.Override(0.5f);
                 turboWarning.SetActive(false);

             }
             else
             {
                 globalObstacleSpeed = 100;
                 vignette.intensity.Override(0.0f);
                 turboWarning.SetActive(true);
             }
         }

         TurboEngineSound.SetActive(turbo);
         normalEngineSound.SetActive(!turbo);
       
         */
    }

    void Spawn()
    {

        //imposible variable checks if the combination of obstacles is impossible to pass, for example
        //avoiding the spawn of 3 unpassable obstacles.

        int posRan = Random.Range(0,positions.Length);

        bool imposible = false;

        for (int i = 0; i < positions.Length; i++)
        {
            int ran = Random.Range(0 , obstacles.Length);   

            if (posRan == i)
            {
                if (!imposible)
                {
                    if (ran == 3)
                    {
                        imposible = true;
                        ran = Random.Range(0, 2);
                    }
                }
            }

            Instantiate(obstacles[ran], positions[i].position, positions[i].rotation);
        }

        imposible = false;

    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(spawnRate);
        Spawn();
        StopAllCoroutines();
        StartCoroutine(Clock());
    }
}
