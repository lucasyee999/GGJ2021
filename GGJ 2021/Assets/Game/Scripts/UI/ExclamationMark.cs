﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationMark : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
