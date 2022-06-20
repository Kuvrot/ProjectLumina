using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [TextArea(5 ,10)]
    public string[] dialogue;
    public int curDialogue;
    public bool finished;
    private bool m_finished;

    public int dialogueSound;

    public AudioClip[] dialogueSFX;
    AudioSource asrce;

    public float writeSpeed = 0.25f; //lowest values mean faster

    public Text textUI;

    // Start is called before the first frame update

    private void OnEnable()
    {
        textUI.text = "";
        asrce = GetComponent<AudioSource>();
        NextDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (curDialogue >= dialogue.Length - 1 && m_finished)
        {
            finished = true;
        }

        if (!finished)
        {
            if (Input.GetButtonDown("Interact") && m_finished)
            {
             
                    textUI.text = "";
                    curDialogue++;
                    NextDialogue();    

            }
            else if (Input.GetButtonDown("Interact") && !m_finished)
            {
                m_finished = true;

            }
        }
      
    }

    void NextDialogue()
    {
        asrce.PlayOneShot(dialogueSFX[dialogueSound]);
        m_finished = false;
        StartCoroutine(Write());
        
    }

    IEnumerator Write()
    {

        if (!m_finished)
        {
            for (int i = 0; i < dialogue[curDialogue].Length; i++)
            {
                yield return new WaitForSeconds(writeSpeed);
                textUI.text += dialogue[curDialogue][i];

                if (m_finished)
                {
                    textUI.text = dialogue[curDialogue];
                    break;
                }

            }

            m_finished = true;
            asrce.Stop();
        }
  

        StopAllCoroutines();
        
    }


}
