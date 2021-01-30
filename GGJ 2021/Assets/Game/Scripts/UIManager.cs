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

    private void Awake()
    {
        if(instance == null)
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
    }

    public void OpenWinView()
    {
        Time.timeScale = 0;
        GameView.SetActive(true);
        WinView.SetActive(true);
        LoseView.SetActive(false);

    }

    public void OpenLoseView()
    {
        Time.timeScale = 0;
        GameView.SetActive(true);
        WinView.SetActive(false);
        LoseView.SetActive(true);
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(0);
    }



}
