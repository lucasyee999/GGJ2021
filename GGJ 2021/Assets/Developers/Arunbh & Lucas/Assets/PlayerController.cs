using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 20.0f;
    public GameObject SpriteMask;

    private void Start()
    {

    }


    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * runSpeed;
        transform.position += velocity * Time.deltaTime;

        Debug.Log(velocity);

    }

    private void LateUpdate()
    {
        SpriteMask.transform.position = transform.position;
    }

}
