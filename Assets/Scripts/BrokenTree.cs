using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTree : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-200 * Time.deltaTime, 0, 0);
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
