using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BallController : MonoBehaviour
{
    public GameObject gameMaster;
    public GameObject player1;
    public GameObject player2;
    public int playerNumber;
    private Rigidbody2D rb;
    public GameObject goal1;
    public GameObject goal2;
    private Vector2 v;
    public AudioClip shootSE;
    AudioSource audioSorce;

    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNumber == 1)
        {
            rb = player1.GetComponent<Rigidbody2D>();
            Vector2 v = rb.velocity.normalized;
            transform.position = player1.transform.position + new Vector3(v.x * 3, v.y * 3, 0);
        }
        else if(playerNumber == 2)
        {
            rb = player2.GetComponent<Rigidbody2D>();
            Vector2 v = rb.velocity.normalized;
            transform.position = player2.transform.position + new Vector3(v.x * 3, v.y * 3, 0);
        }
    }

    private void FixedUpdate()
    {
        //シュートに関する記述
        if (Input.GetKeyDown(KeyCode.Return) && playerNumber == 1)
        {
            audioSorce.PlayOneShot(shootSE);
            v = goal1.transform.position - transform.position + new Vector3(0, Random.Range(-2, 2), 0);
            transform.GetComponent<Rigidbody2D>().AddForce(v*0.1f);
            playerNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerNumber == 2)
        {
            audioSorce.PlayOneShot(shootSE);
            v = goal2.transform.position - transform.position + new Vector3(0, Random.Range(-2, 2), 0);
            transform.GetComponent<Rigidbody2D>().AddForce(v*0.1f);
            playerNumber = 0;
        }
        //ここまで
        GetComponent<Rigidbody2D>().velocity *= 0.98f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //得点に関する記述
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("wwww");
            //ゴールテキストを表示
            UIController uiController = gameMaster.GetComponent<UIController>();
            Vector3 pos = uiController.goalText.transform.position;
            pos.x = 10;
            uiController.goalText.transform.position = pos;
            //得点追加
            GameController controller = GameObject.Find("GameMaster").GetComponent<GameController>();
            //ボールを止める
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //プレイヤーを止める
            player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //ポジションのリセット
            GameController gameController = gameMaster.GetComponent<GameController>();
            if(collision.name == "Goal1")
            {
                controller.AddScore(1);
                StartCoroutine(gameController.ResumeGame(1));
            }
            else
            {
                controller.AddScore(2);
                StartCoroutine(gameController.ResumeGame(2));
            }
        }
        //ここまで


        //コートに関する記述
        if(collision.gameObject.tag == "Court")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //攻守交代に関する記述
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player1")
            {
                playerNumber = 1;
            }
            if (collision.gameObject.name == "Player2")
            {
                playerNumber = 2;
            }
        }
        //ここまで
    }
}
