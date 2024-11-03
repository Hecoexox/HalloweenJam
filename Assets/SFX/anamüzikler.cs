using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip firstTrack; 
    public AudioClip secondTrack; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayFirstTrack(); 
    }

    void PlayFirstTrack()
    {
        audioSource.clip = firstTrack;
        audioSource.Play();
        StartCoroutine(WaitForFirstTrack());
    }

    IEnumerator WaitForFirstTrack()
    {
       
        yield return new WaitForSeconds(firstTrack.length);
        PlaySecondTrack(); 
    }

    void PlaySecondTrack()
    {
        audioSource.clip = secondTrack;
        audioSource.Play();
        StartCoroutine(WaitForSecondTrack());
    }

    IEnumerator WaitForSecondTrack()
    {
       
        yield return new WaitForSeconds(secondTrack.length);
        PlayFirstTrack();
    }
}
