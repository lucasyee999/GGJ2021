using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Relic;
    public GameObject BigBlackBG;
    public GameObject EscapePoint;

    public bool found = false;
    public bool GameStarted = false;
    public PlayableDirector startingCutScene;
    public PlayableDirector endingCutScene;

    [HideInInspector] public PlayerController playerController;
    private EnemyController[] allEnemies;


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
        EscapePoint.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
        allEnemies = FindObjectsOfType<EnemyController>();
        playerController.enabled = false;
        startingCutScene.RebuildGraph();
        startingCutScene.time = 0;
        startingCutScene.Play();
        SoundManager.instance.StopAllSound();
        SoundManager.instance.PlayBGM(3);
    }

    public void StartGame()
    {
        playerController.enabled = true;
        GameStarted = true;
        UIManager.instance.GameView.SetActive(true);
    }


    #region Found

    public void Found()
    {
        playerController.enabled = false;
        playerController.rigid.velocity = Vector2.zero;
        endingCutScene.Play();
        SoundManager.instance.PlaySFX(7);
    }

    public void Found2()
    {
        SoundManager.instance.StopAllSound();
        SoundManager.instance.PlayBGM(2);
        Relic.SetActive(false);
        found = true;
        playerController.enabled = true;

        Transform player = FindObjectOfType<PlayerController>().transform;
        foreach (EnemyController enemy in allEnemies)
        {
            enemy.stateMachine.ChangeState(new EnemyChaseState(enemy, player));
        }
        EscapePoint.SetActive(true);
        UIManager.instance.OpenFoundView();
        MinimapManager.instance.RevealWholeMinimap();
    }

    #endregion

    #region Escaped

    public void Escaped()
    {
        UIManager.instance.OpenWinView();
    }


    #endregion
}
