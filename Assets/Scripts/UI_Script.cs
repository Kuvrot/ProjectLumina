using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{

    public bool infinteMode;

    public float score = 0;
    public Text text;
    public Slider progress;

    [HideInInspector]public bool play;

    PlayerController pl;

    GameManager gm;

    float Timer;

    public GameObject VictoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gm = GameManager.gameManager.GetComponent<GameManager>();
        //progress.maxValue = 150;
    }

    // Update is called once per frame
    void Update()
    {

        if (infinteMode)
        {

            text.gameObject.SetActive(true);

            if (!pl.death && play)
            {
                score += 10 * Time.deltaTime;
                text.text = "Score: " + score.ToString("F0");
            }


            }
        else
        {

            progress.gameObject.SetActive(true);

            if (!pl.death && play)
            {
                Timer += 1 * Time.deltaTime;
                progress.value = Timer;

                if (Timer >= progress.maxValue)
                {
                    gm.globalObstacleSpeed -= 50 * Time.deltaTime;
                }
            }

            if (gm.globalObstacleSpeed <= 0)
            {
                gm.globalObstacleSpeed = 0;
                VictoryScreen.SetActive(true);
            }
        }

       
    }

    public void ReturnToCity()
    {
        SceneManager.LoadScene("City");

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
