using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Relic;
    public GameObject BigBlackBG;
    public GameObject EscapePoint;

    public bool found = false;

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
    }


    #region Found

    public void Found()
    {
        SoundManager.instance.StopAllSound();
        SoundManager.instance.PlayBGM(2);
        playerController.enabled = false;
        playerController.rigid.velocity = Vector2.zero;
        playerController.SpriteMask.transform.DOScale(new Vector3(500, 500), 2f).OnComplete(Found2);

    }

    public void Found2()
    {
        Relic.SetActive(false);
        found = true;
        playerController.enabled = true;

        Transform player = FindObjectOfType<PlayerController>().transform;
        foreach (EnemyController enemy in allEnemies)
        {
            enemy.stateMachine.ChangeState(new EnemyChaseState(enemy, player));
        }
        EscapePoint.SetActive(true);
    }

    #endregion

    #region Escaped

    public void Escaped()
    {
        UIManager.instance.OpenWinView();
    }


    #endregion



}
