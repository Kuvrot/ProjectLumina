using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeSystem : MonoBehaviour
{
    public int state = 2; // State 0 fade in,  1 is fade out , 2 fade in and out 
    public float speed = 5;
    Animator anim;
    Image fade;
    [HideInInspector] public bool m_faded, m_doubleFaded;

    public GameObject[] destroyObjects;

    // Start is called before the first frame update
    void OnEnable()
    {
        fade = GetComponentInChildren<Image>();
        anim = GetComponentInChildren<Animator>();
        anim.SetInteger("State", state);

     

    }

    private void Update()
    {
        if (m_faded)
        {
            EndFade();
        }

        if (m_doubleFaded)
        {
            f_endDoubleFade();
        }
    }

    public void EndFade()
    {

           if (state == 0 || state == 1)
        {
            if (destroyObjects.Length >= 1)
            {
                for (int i = 0; i < destroyObjects.Length; i++)
                {
                    Destroy(destroyObjects[i]);
                }
            }
        }


            Destroy(this.gameObject);
        

    }

    public void f_endDoubleFade()
    {
        if (destroyObjects.Length >= 1)
        {
            for (int i = 0; i < destroyObjects.Length; i++)
            {
                Destroy(destroyObjects[i]);
            }
        }
    }
}
