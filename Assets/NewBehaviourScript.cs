using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float ActivateAfterSeconds = 10;
    public GameObject ObjectToActivate;

    private void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(ActivateAfterSeconds);
        ObjectToActivate.SetActive(true);

    }

}
