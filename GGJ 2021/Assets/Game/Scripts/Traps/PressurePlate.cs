﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] GameObjectsToDisable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlaySFX(6);
            foreach(GameObject go in GameObjectsToDisable)
            {
                go.SetActive(false);
            }
        }


    }


}
