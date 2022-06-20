using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPlayerController : MonoBehaviour
{

    public float mouseSens;
    public float speed;

    public float maxAngle = 45;
    public float minAngle = -90;

    public float curAngle;

    public Transform cam;

     public bool interacting;

    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called twice per frame
    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 mov = (Vector3.forward * v + Vector3.right * h);




        if (!interacting)
        {
            Vector3 MoveDir = this.transform.TransformDirection(mov);
            GetComponent<CharacterController>().Move(MoveDir * Time.deltaTime * speed);
        }

    }
    // Update is called once per frame
    void Update()
    {

        float m_v = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        float m_h = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;

        curAngle += -m_v;

        curAngle = Mathf.Clamp(curAngle , minAngle , maxAngle);


        // GetComponent<Rigidbody>().MoveRotation(new Quaternion (0, m_h, 0,3));
        transform.Rotate(Vector3.up * m_h);
        cam.transform.localEulerAngles = new Vector3(curAngle, 0 , 0);

        



    }
}
