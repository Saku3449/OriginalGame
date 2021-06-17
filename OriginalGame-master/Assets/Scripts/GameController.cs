using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //スコア
    public static int score1;
    public static int score2;
    //プレーヤー
    public GameObject player1;
    public GameObject player2;
    //ボール
    public GameObject ball;
    //プレハブ
    public GameObject Prefab;
    //操作中か
    public bool isPlaying;

    AudioContoroller ac;

    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
        for (int i = 0; i < CreateObjectController.clickPosition.Length; i++)
        {
            Instantiate(Prefab, Camera.main.ScreenToWorldPoint(CreateObjectController.clickPosition[i]), Prefab.transform.rotation);
        }
        ac = GetComponent<AudioContoroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //得点時の記述
    public IEnumerator ResumeGame(int i)
    {
        yield return new WaitForSeconds(2);
        if(i == 1)
        {
            player1.transform.position = new Vector3(10, 0, 0);
            player2.transform.position = new Vector3(-1.8f, 0, 0);
        }
        else
        {
            player1.transform.position = new Vector3(1.8f, 0, 0);
            player2.transform.position = new Vector3(-10, 0, 0);
        }
        ball.transform.position = new Vector3(0, 0, 0);
        isPlaying = true;
    }

    public int GetScore(int i)
    {
        if(i == 1)
        {
            return score1;
        }
        else
        {
            return score2;
        }
    }

    public void AddScore(int i)
    {
        if(i == 1)
        {
            ac.GoalSound();
            score1++;
        }
        else {
            ac.GoalSound();
            score2++;
        }
        
    }
    //ここまで
}
