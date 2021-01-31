using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject GameView;
    public GameObject WinView;
    public GameObject LoseView;
    public GameObject FoundView;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        OpenGameView();
    }

    public void OpenGameView()
    {
        Time.timeScale = 1;
        GameView.SetActive(true);
        WinView.SetActive(false);
        LoseView.SetActive(false);
        FoundView.SetActive(false);
        SoundManager.instance.PlayBGM(3);
    }

    public void OpenWinView()
    {
        Time.timeScale = 0;
        WinView.SetActive(true);
        LoseView.SetActive(false);

        SoundManager.instance.StopAllSound();
        SoundManager.instance.PlaySFX(4);
    }

    public void OpenLoseView()
    {
        Time.timeScale = 0;
        WinView.SetActive(false);
        LoseView.SetActive(true);

        SoundManager.instance.StopAllSound();
        SoundManager.instance.PlaySFX(0);
    }

    public void OpenFoundView()
    {
        Time.timeScale = 1;
        GameView.SetActive(false);
        WinView.SetActive(false);
        LoseView.SetActive(false);
        FoundView.SetActive(true);
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
