using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text resultText;
    public Text playerText;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "1P | " + GameController.score1.ToString() + " - " + GameController.score2.ToString() + " | 2P";
        if(GameController.score1 > GameController.score2)
        {
            playerText.text = "Player1\nWin!!";
            player1.gameObject.SetActive(true);
        }
        else if (GameController.score1 < GameController.score2)
        {
            playerText.text = "Player2\nWin!!";
            player2.gameObject.SetActive(true);
        }
        else
        {
            playerText.text = "Good\nGame!";
            player1.gameObject.SetActive(true);
            player1.transform.position = new Vector3(6.21f, -1.32f, 0);
            player2.gameObject.SetActive(true);
            player2.transform.position = new Vector3(2.71f, -1.28f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        //audioSource.PlayOneShot(se);
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }
}
