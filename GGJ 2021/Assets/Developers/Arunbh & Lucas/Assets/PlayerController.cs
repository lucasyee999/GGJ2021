using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 20.0f;
    public GameObject SpriteMask;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * runSpeed;
        //transform.position += velocity * Time.deltaTime;
        rb.velocity = (Vector2)velocity;
    }

    private void LateUpdate()
    {
        if (SpriteMask != null)
        {
            SpriteMask.transform.position = transform.position;
        }
    }

}
