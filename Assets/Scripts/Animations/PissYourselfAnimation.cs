using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissYourselfAnimation : ActionAnimation
{
    public AudioSource MusicAudioSource;
    public AudioSource KenAudio;
    public AudioClip PeedYourselfClip;
    public AudioClip ScratchClip;

    private void Update()
    {
        if (IsRunning)
        {
            IsRunning = false;
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
    }      
}
