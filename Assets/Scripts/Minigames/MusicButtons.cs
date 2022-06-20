using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButtons : MonoBehaviour
{

    public string buttonName;
    Text text;
    float buttonTimer;

    public bool noteIn;

    MusicMinigame mmg;

    Collider note;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        mmg = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MusicMinigame>();
        text = GetComponentInChildren<Text>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer -= 1 * Time.deltaTime;

        if (Input.GetButtonDown(buttonName))
        {
            buttonTimer = 0.1f;

            if (noteIn)
            {  
                mmg.Score++;
                if (note != null) { Destroy(note.gameObject); }
                anim.SetTrigger("Good");
                noteIn = false;
            }
        }

        if (buttonTimer > 0)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = Color.black;
        }

       

    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Note")
        {
            noteIn = true;
            note = other;

        }
    }
    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Note")
        {
            noteIn = false;
            note = other;
            if (note != null) { Destroy(note.gameObject); }
            
        }
    }
}
