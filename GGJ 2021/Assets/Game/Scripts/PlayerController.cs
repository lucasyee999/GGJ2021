using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid { get { return rb; } }

    public float runSpeed = 20.0f;
    public float theSpeed;
    public GameObject SpriteMask;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Sprite DownSprite;
    public Sprite UpSprite;
    public Sprite SideSprite;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        theSpeed = runSpeed;
        sr = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * theSpeed;
        //transform.position += velocity * Time.deltaTime;
        rb.velocity = velocity;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.localScale = Vector3.one;
            sr.sprite = UpSprite;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.localScale = Vector3.one;
            sr.sprite = DownSprite;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            sr.sprite = SideSprite;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = Vector3.one;
            sr.sprite = SideSprite;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            sr.sprite = UpSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            sr.sprite = DownSprite;
        }
    }

    private void LateUpdate()
    {
        if (SpriteMask != null)
        {
            SpriteMask.transform.position = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Relic")
        {
            GameManager.instance.Found();
        }
        else if (other.collider.tag == "Escape")
        {
            GameManager.instance.Escaped();
        }
    }

}
