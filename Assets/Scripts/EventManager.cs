using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    public GameObject pressEtext;

    public GameObject[] events;

    public int curEvent;

    public bool startOnAwake = false;

    public bool canInteract , initiated;
   // bool eventEnd = false;

    //enable if the last event is a fade.
    public bool lastEventIsAFade;

    // Start is called before the first frame update
    void Start()
    {
       if (startOnAwake)
        {
            initiated = true;
            InitEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact") && initiated)
        {
            if (events[curEvent].GetComponent<DialogueSystem>())
            {
                if (events[curEvent].GetComponent<DialogueSystem>().finished)
                { 
                    NextEvent();
                }
            }
        }

        if (Input.GetButtonDown("Interact") && canInteract && !initiated)
        {
            initiated = true;
            InitEvent();
        }

        if (lastEventIsAFade)
        {
            if (events[events.Length - 1] == null)
            {
                initiated = false;
                CityManager.player.GetComponent<CityPlayerController>().interacting = false;
                Destroy(this.gameObject);

            }
        }

        

        if (pressEtext != null && !initiated)
        {
            pressEtext.SetActive(canInteract);

        }else if (pressEtext != null && initiated)
        {
            pressEtext.SetActive(false);
        }

    }

    private void NextEvent()
    {

        events[curEvent].SetActive(false);

        

        if (curEvent + 1 < events.Length)
        {
            curEvent++;
            events[curEvent].SetActive(true);
        }
        else
        {
            if (!lastEventIsAFade)
            {
                CityManager.player.GetComponent<CityPlayerController>().interacting = false;
                initiated = false;
                canInteract = false;
                curEvent = 0;
            }
        }

    }
        
    void InitEvent()
    {
        CityManager.player.GetComponent<CityPlayerController>().interacting = true;
        events[curEvent].SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!startOnAwake)
            {
                canInteract = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!startOnAwake)
            {
                canInteract = false;
            }
        }
    }

}
