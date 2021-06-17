using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Text gamesetText;
    public Text goalText;
    public Text countDonwText;
    public GameController controller;
    public float time;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameMaster").GetComponent<GameController>();
        StartCoroutine(GameStart());
    }

    // Update is called once per frame
    void Update()
    {
        //UIに関する記述
        scoreText.text = "1P | " + controller.GetScore(1) + " - " + controller.GetScore(2) + " | 2P";
        time -= Time.deltaTime;
        timerText.text = new TimeSpan(0, 0, (int)time).ToString(@"mm\:ss");
        //ここまで

        //シーン移動
        if (time < 0)
        {
            controller.isPlaying = false;
            time = 0;
            player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gamesetText.gameObject.SetActive(true);
            Invoke("ChangeScene", 2.0f);
        }
        //ここまで
    }

    private void FixedUpdate()
    {
        //ゴールテキストのカットイン
        goalText.transform.position += new Vector3(-1, 0, 0);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Result");
    }

     public IEnumerator GameStart()
    {
        timerText.gameObject.SetActive(false);
        countDonwText.gameObject.SetActive(true);
        controller.isPlaying = false;
        countDonwText.text = "3";
        yield return new WaitForSeconds(1);
        countDonwText.text = "2";
        yield return new WaitForSeconds(1);
        countDonwText.text = "1";
        yield return new WaitForSeconds(1);
        countDonwText.text = "Start!";
        controller.GetComponent<AudioContoroller>().StartSound();
        yield return new WaitForSeconds(1);
        controller.isPlaying = true;
        countDonwText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
    }

}
