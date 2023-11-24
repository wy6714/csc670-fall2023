using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    private float speed = 5f;

    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    public static event Action<GameObject> collectFruit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //run animation
        if (horizontal > 0f || horizontal < 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Flip();
    }

    private void Flip()//change side
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            collectFruit?.Invoke(other.gameObject);
        }
    }
}
