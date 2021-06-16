using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動速度
    private float speed;
    //移動方向
    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveVector;
    //PlayerのRigidBody
    Rigidbody2D rbPlayer;
    //アニメーション
    Animator walkAnimator;
    //ゴール
    public GameObject Goal1;
    public GameObject Goal2;

    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15.0f;
        rbPlayer = GetComponent<Rigidbody2D>();
        walkAnimator = GetComponent<Animator>();
        gc = GameObject.Find("GameMaster").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動方向をリセット
        verticalInput = 0;
        horizontalInput = 0;

        //プレイ可能ならば
        if(gc.isPlaying)
        {
            //Player1に関する記述
            if (this.gameObject.name == "Player1")
            {
                //移動に関する記述
                moveVector = Vector2.zero;

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    verticalInput = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    verticalInput = -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    horizontalInput = 1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    horizontalInput = -1;
                }
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    rbPlayer.velocity = Vector2.zero;
                }

                moveVector.x = speed * horizontalInput;
                moveVector.y = speed * verticalInput;

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    rbPlayer.AddForce(moveVector);
                }

                rbPlayer.velocity *= 0.98f;
                //ここまで

            }

            //Player2に関する記述
            if (this.gameObject.name == "Player2")
            {
                //移動に関する記述
                moveVector = Vector2.zero;

                if (Input.GetKey(KeyCode.W))
                {
                    verticalInput = 1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    horizontalInput = -1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    verticalInput = -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    horizontalInput = 1;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    rbPlayer.velocity = Vector2.zero;
                }

                moveVector.x = speed * horizontalInput;
                moveVector.y = speed * verticalInput;

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    rbPlayer.AddForce(moveVector);
                }

                rbPlayer.velocity *= 0.99f;
                //ここまで

            }

            //アニメーションに関する記述
            walkAnimator.SetFloat("x", moveVector.x);
            walkAnimator.SetFloat("y", moveVector.y);
            if (rbPlayer.velocity == Vector2.zero)
            {
                walkAnimator.speed = 0;
            }
            else
            {
                walkAnimator.speed = 1;
                walkAnimator.SetFloat("x", moveVector.x);
                walkAnimator.SetFloat("y", moveVector.y);
            }
            //ここまで
        }

    }
}
