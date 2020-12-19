using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource hat;
    bool isCoroutineRunning = false;
    void Start()
    {
        hat = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (isCoroutineRunning == true)
        {
            StopCoroutine("PlaySoundCoroutine");
            StartCoroutine("PlaySoundCoroutine");
        }
        else
            StartCoroutine("PlaySoundCoroutine");
    }

    IEnumerator PlaySoundCoroutine()
    {
        hat.Play();
        isCoroutineRunning = true;
        yield return
        isCoroutineRunning = false;
    }
}
