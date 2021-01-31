using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.PlayBGM(5);
    }

    public void OnStartButtonClicked()
    {
        SoundManager.instance.StopAllSound();
        SceneManager.LoadScene(1);
    }
}
