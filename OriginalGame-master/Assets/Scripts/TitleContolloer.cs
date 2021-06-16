using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleContolloer : MonoBehaviour
{
    public AudioClip se;
    AudioSource audioSorce;

    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSorce.PlayOneShot(se);
            Invoke("LoadSceneMain", 1.5f);
        }
    }

    private void LoadSceneMain()
    {
        
        SceneManager.LoadScene("Select");
    }
}
