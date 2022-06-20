using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefensePlayer : MonoBehaviour
{

    public float MouseSens = 150;
    public float fireRate = 0.15f;

    float h;
    float v;

    float curAngleY;

    public ParticleSystem muzzleFlash;
    public GameObject bloodFX , genericImpactFX;

    public AudioClip shootSFX;

    bool canShoot = true;

    //UI

    public Text scoreUI, AmmoUI, WaveUI;

    // Este codigo debe ser editado para tener la variable estática de desbloquear el raton.


    AudioSource asrce;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        asrce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        v = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        curAngleY -= v;
        //curAngleX += h;

        curAngleY = Mathf.Clamp(curAngleY, -45, 45);

        transform.Rotate(0, h, 0);

        Camera.main.transform.localRotation = Quaternion.Euler(curAngleY, 0, 0);

        Selecting();

       if (Input.GetButton("Fire1"))
        {
            if (canShoot)
            {
                shoot();
            }
               
        }


        if (Input.GetButtonDown("Interact"))
        {
                Selected();
        }

        // transform.localEulerAngles = new Vector3(Mathf.Clamp(curAngleY, -45, 45),0 , 0);

    }

    void shoot()
    {
        anim.SetTrigger("Shoot");
        muzzleFlash.Play();
        asrce.PlayOneShot(shootSFX);


        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position , Camera.main.transform.forward , out hit))
        {
            if (GetComponent<EnemyController>())
            {
                Instantiate(bloodFX, hit.point, Quaternion.LookRotation(transform.position));
            }
            else
            {
                Instantiate(genericImpactFX, hit.point, Quaternion.LookRotation(transform.position));
            }
        }

        canShoot = false;
        StartCoroutine(rate());
    }


    IEnumerator rate()
    {
        
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        StopAllCoroutines();
    }

    void Selecting ()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
          
        }
    }

    void Selected()
    {

    }
}
