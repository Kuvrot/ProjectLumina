using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFADE : MonoBehaviour
{


    public void endFade()
    {
        GetComponentInParent<FadeSystem>().m_faded = true;
    }

    public void endDoubleFade()
    {
        GetComponentInParent<FadeSystem>().m_doubleFaded = true;
    }

}
