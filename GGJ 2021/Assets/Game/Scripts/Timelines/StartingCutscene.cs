using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCutscene : MonoBehaviour
{
    public void CutsceneEnd()
    {
        GameManager.instance.StartGame();
    }
}
