using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool selected = false;

    public GameObject m_selectedObject;

    public Transform door;

    Text text;

    LuminaController lc;

    Color m_color;

    // Start is called before the first frame update
    void Start()
    {
        //   m_selectedObject = GetComponentInChildren<GameObject>();
        lc = CityManager.player.GetComponent<LuminaController>();
        text = GetComponentInChildren<Text>();

        m_color = text.color;

    }

    // Update is called once per frame
    void Update()
    {
        m_selectedObject.SetActive(selected);

        if (selected)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = m_color;
        }

        if (!lc.m_key)
        {
            selected = false;
        }
    }

}
