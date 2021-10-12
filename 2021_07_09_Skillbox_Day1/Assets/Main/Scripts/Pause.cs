using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public Button pauseButton;

    public GameObject menuPause;
    public GameObject uiPanel;

    public Button continueButton;
    public Button exitButton;

    public static bool isPause = false;

    void Start()
    {

        pauseButton.onClick.AddListener(delegate {
            isPause = true;
            uiPanel.SetActive(false);
            menuPause.SetActive(true);
            Time.timeScale = 0f;
        });

        continueButton.onClick.AddListener(delegate {
            isPause = false;
            uiPanel.SetActive(true);
            menuPause.SetActive(false);
            Time.timeScale = 1f;
        });

        exitButton.onClick.AddListener(delegate {
            isPause = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        });
    }
}
