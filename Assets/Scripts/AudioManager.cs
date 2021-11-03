using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundClick;
    [SerializeField] private AudioClip soundWin;
    [SerializeField] private AudioClip soundLose;

    public void PlayClickSound()
    {
        audioSource.clip = soundClick;
        audioSource.Play();

    }

    public void PlayWinSound()
    {
        audioSource.clip = soundWin;
        audioSource.Play();

    }

    public void PlayLoseSound()
    {
        audioSource.clip = soundLose;
        audioSource.Play();

    }



}
