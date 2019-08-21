using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject btnContinue;

    private void Start()
    {
        string levelName = PlayerPrefsManager.loadLevel();
        if (levelName != "")
            btnContinue.SetActive(true);
        else
            btnContinue.SetActive(false);
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void loadSavedScene()
    {
        string levelName = PlayerPrefsManager.loadLevel();
        if(levelName != "")
            SceneManager.LoadScene(levelName);
    }
}
