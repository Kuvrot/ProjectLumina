using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceen : MonoBehaviour
{
    public float loadingTime = 5f;
    public GameObject loadingScreen;
    public GameObject[] loadObjects;
    public Transform Circle;
    UI_Script ui;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clock());
        ui = GetComponent<UI_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        Circle.transform.Rotate(0, 0, 500 * Time.deltaTime);


    }

    IEnumerator Clock ()
    {
        yield return new WaitForSeconds(loadingTime);

        for (int i = 0; i < loadObjects.Length; i++)
        {
            loadObjects[i].SetActive(true);
        }

        ui.play = true;
        loadingScreen.SetActive(false);
        Destroy(this);

    }
}
