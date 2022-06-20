using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeSpawningSystem : MonoBehaviour
{

    public GameObject tree;
    public Transform[] spawns;
    public float spawnRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CLOCK());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CLOCK()
    {
        yield return new WaitForSeconds (spawnRate);

        for (int i = 0; i < spawns.Length; i++)
        {
            int ran = Random.Range(0, 2);

           if (ran == 1)
            {
                Instantiate(tree, spawns[i].position, spawns[i].rotation);
            }
        }

        StopAllCoroutines();
        StartCoroutine(CLOCK());

    }

    
}
