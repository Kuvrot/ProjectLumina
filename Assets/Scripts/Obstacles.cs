using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //1 is low 2 is high , 3 is breakeble , 4 not breakable
    public int type;

    public GameObject brokenObstacle;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.gameManager.GetComponent<GameManager>();

        if (type == 1)
        {
            transform.position += new Vector3(0, 5, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0, -gm.globalObstacleSpeed) * Time.deltaTime;
    }


    public void Destruction()
    {
        if (brokenObstacle != null)
        {
            Instantiate(brokenObstacle, transform.position + new Vector3(0, -10, 0), transform.rotation);
        }
        Destroy(this.gameObject);
    }

}
