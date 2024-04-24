using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    AudioSource audioSource;
    public bool muted;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMuted()
    {
        muted = !muted;
        audioSource.mute = muted;
    }

    public AudioClip menuButtonSfx;
    public void PlayMenuButtonSfx()
    {
        audioSource.PlayOneShot(menuButtonSfx);
    }

    public AudioClip playerJumpSfx;
    public void PlayJumpSfx()
    {
        audioSource.PlayOneShot(playerJumpSfx);
    }

    public AudioClip coinSfx;
    public void PlayCoinSfx()
    {
        audioSource.PlayOneShot(coinSfx);
    }
}
