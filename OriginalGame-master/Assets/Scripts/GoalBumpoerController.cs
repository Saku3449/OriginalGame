using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBumpoerController : MonoBehaviour
{
    public Vector2 v;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        v = new Vector2(0, 10);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = v;
        if(Mathf.Abs(transform.position.y) > 14.45)
        {
            v *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        v *= -1;
    }
}
