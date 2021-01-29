using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playervelocity : MonoBehaviour
{
    public float runSpeed = 20.0f;


    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * runSpeed;
        transform.position += velocity * Time.deltaTime;

    }

}
