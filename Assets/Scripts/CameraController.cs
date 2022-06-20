using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

   public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 12f, transform.position.z), 10);
            
    }
}
