using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string loadScene;
    private void OnEnable()
    {
        SceneManager.LoadScene(loadScene);
    }
}
