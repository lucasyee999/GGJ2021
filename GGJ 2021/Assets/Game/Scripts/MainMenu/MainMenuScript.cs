using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.PlayBGM(3);
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
