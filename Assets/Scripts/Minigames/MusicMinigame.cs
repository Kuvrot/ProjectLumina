using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicMinigame : MonoBehaviour
{

    //Retraso de 4.54 segundos por nota
    //La canción dura 251.5757 segundos;

    public float Score;
    public float maxscore;
    float realScore;

    public bool record;

    public int selectedMusic = 0;

    public List<string> RecordedInput;
    public List<float> RecordedTime;

    public float timer;

    AudioSource asrce;

    public AudioClip[] Music;

    public bool playing;

    public GameObject canvas;

    public Slider bar;

    //notes
    public Transform[] spawnPos;
    public GameObject note;

    Image img_note;
    Text noteText;

    int noteCounter;
    int selectPos;

    Rect r;

    //bool start; 

     bool music_ended;
    public GameObject endScreen;
    public Text t_score;
    public Text bestScore;


    bool s;


    // Start is called before the first frame update
    void Start()
    {
        asrce = GetComponent<AudioSource>();
        img_note = note.GetComponent<Image>();
        noteText = note.GetComponentInChildren<Text>();
       
        playing = true;

        PlayMusic();
        timer = 0;

        if (PlayerPrefs.HasKey("MusicMaxScore"))
        {
            maxscore = PlayerPrefs.GetFloat("MusicMaxScore");
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        //timer = Time.timeSinceLevelLoad;
        bar.value = timer;

        if (record)
        {

            
           //timer = asrce.time;
            if (Input.GetButtonDown("Extra"))
            {
                RecordedInput.Add("Jump");
                addTime();
            }
            if (Input.GetButtonDown("Down"))
            {
                RecordedInput.Add("Down");
                addTime();
            }

            if (Input.GetButtonDown("Left"))
            {
                RecordedInput.Add("Left");
                addTime();
            }
            if (Input.GetButtonDown("Right"))
            {
                RecordedInput.Add("Right");
                addTime();
            }

            

        }
        else
        {
          if (!music_ended)
            {
                if (noteCounter < RecordedInput.Count)
                {
                    if (timer >= RecordedTime[noteCounter] - 4.5f)
                    {
                        switch (RecordedInput[noteCounter])
                        {
                            case "Left": selectPos = 0; img_note.color = Color.red; noteText.text = "A"; break;
                            case "Down": selectPos = 1; img_note.color = Color.green; noteText.text = "S"; break;
                            case "Right": selectPos = 2; img_note.color = Color.blue; noteText.text = "D"; break;
                            case "Jump": selectPos = 3; img_note.color = Color.yellow; noteText.text = "F"; break;
                        }

                        GameObject newNote;
                        newNote = Instantiate(note, spawnPos[selectPos].position, spawnPos[selectPos].rotation);
                        newNote.transform.SetParent(canvas.transform);

                        noteCounter++;
                    }
                }
            }
            else
            {

                if (!s) {
                    timer = 0;

                    realScore = (Score / RecordedInput.Count) * 100;

                    if (realScore > maxscore)
                    {
                        maxscore = realScore;
                        PlayerPrefs.SetFloat("MusicMaxScore", maxscore);
                    }

                    endScreen.SetActive(true);

                    t_score.text = "Score: " + realScore.ToString("F1") + "%";
                    bestScore.text = "Best score: " + maxscore.ToString("F1") + "%";
                    s = true;
                }
            }

        }

        if (bar.value >= bar.maxValue)
        {
            music_ended = true;
        }


        }

        void PlayMusic()
    {
        asrce.PlayOneShot(Music[selectedMusic]);
    }


    void addTime ()
    {
        RecordedTime.Add(timer);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoBackLumina()
    {
        SceneManager.LoadScene("City");
    }
 
}
