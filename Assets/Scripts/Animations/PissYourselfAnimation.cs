using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissYourselfAnimation : ActionAnimation
{
    private AudioClip _musicClip;
    private bool _oldLoop;

    public AudioSource MusicAudioSource;
    public AudioSource KenAudio;
    public AudioClip PeedYourselfClip;
    public AudioClip ScratchClip;

    private void Awake()
    {
        _musicClip = MusicAudioSource.clip;
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (!KenAudio.isPlaying)
            {
                MusicAudioSource.clip = _musicClip;
                MusicAudioSource.loop = _oldLoop;
                MusicAudioSource.Play();
                IsRunning = false;
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _oldLoop = MusicAudioSource.loop;
        MusicAudioSource.clip = ScratchClip;
        MusicAudioSource.loop = false;
        MusicAudioSource.Play();
        KenAudio.clip = PeedYourselfClip;
        KenAudio.Play();
    }      
}
