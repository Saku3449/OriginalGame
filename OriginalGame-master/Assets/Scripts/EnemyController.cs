using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gc = GameObject.Find("GameMaster").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.isPlaying)
        {
            int r1 = Random.Range(0, 10);
            int r2 = Random.Range(0, 10);
            if (r1 == r2)
            {
                rb.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * speed;
            }
        }
    }

}
