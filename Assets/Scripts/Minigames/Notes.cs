using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Notes : MonoBehaviour
{

    public float speed;
    public float speed2;
    RectTransform r;
    public int res;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        res = Screen.currentResolution.height;
        speed2 = Screen.currentResolution.height  * 250 / 1080;

        transform.Translate(0,  -speed2 * Time.deltaTime , 0);

        Vector3 temp = r.localScale;
        temp.x = Screen.currentResolution.width / 1080;
        temp.y = Screen.currentResolution.height / 1080;
        r.localScale = temp;
        //r.width = Screen.currentResolution.height / 1080;
    }
}
