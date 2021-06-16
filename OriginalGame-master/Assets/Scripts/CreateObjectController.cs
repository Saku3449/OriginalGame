using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateObjectController : MonoBehaviour
{
    //クリックした位置
    public static Vector3[] clickPosition;
    private int idx;
    //生成したいPrefab
    public GameObject Prefab;

    public Text playerText;
    private int sceneCounter;

    public AudioClip se;
    AudioSource audioSorce;


    // Start is called before the first frame update
    void Start()
    {
        clickPosition = new Vector3[4];
        idx = 0;
        sceneCounter = 0;
        audioSorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneCounter == 4)
        {
            StartCoroutine(LoadMainScene());
        }
        playerText.text = "Player" + (idx%2+1).ToString() + "が設置中";
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }

    public void OnClickAble()
    {
        if (sceneCounter < 4)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] collider2D = Physics2D.OverlapPointAll(new Vector2(worldPoint.x, worldPoint.y));
            if(collider2D.Length < 2)
            {
                clickPosition[idx] = Input.mousePosition;
                clickPosition[idx].z += 10f;
                Instantiate(Prefab, Camera.main.ScreenToWorldPoint(clickPosition[idx]), Prefab.transform.rotation);
                sceneCounter++;
                idx++;
                audioSorce.PlayOneShot(se);
            }

        }
    }
}
