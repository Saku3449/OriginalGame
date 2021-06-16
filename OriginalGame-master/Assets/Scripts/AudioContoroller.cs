using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContoroller : MonoBehaviour
{
    AudioSource audioSorce;
    public AudioClip goalSE;
    public AudioClip startSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoalSound()
    {
        audioSorce.PlayOneShot(goalSE);
    }

    public void StartSound()
    {
        audioSorce.PlayOneShot(startSE);
    }
}
