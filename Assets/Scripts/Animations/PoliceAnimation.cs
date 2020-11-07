using UnityEngine;

public class PoliceAnimation : ActionAnimation
{
    public AudioSource KenAudio;
    public AudioClip PoliceClip;


    public void Update()
    {
        if (IsRunning)
        {
            if (!KenAudio.isPlaying)
            {
                KenAudio.clip = PoliceClip;
                KenAudio.Play();
            }
            if (!KenAudio.isPlaying)
            {
                IsRunning = false;
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
    }
}
