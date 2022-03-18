using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    AudioClip curClip;
    float clipTime;
    public void Start()
    {
        StartCoroutine(ChangeMusic());
    }
    IEnumerator ChangeMusic()
    {
        while (true)
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            clipTime = audioSource.clip.length + 5;
            print(clipTime);
            audioSource.Play();
            yield return new WaitForSecondsRealtime(clipTime);
        }
    }
}