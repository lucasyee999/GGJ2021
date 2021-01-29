using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraclamp : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(0,-11.4f,8.4f), Mathf.Clamp(0, 1.5f,-7.9f),transform.position.z);


    }
}