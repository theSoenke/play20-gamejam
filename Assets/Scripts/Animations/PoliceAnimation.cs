using UnityEngine;

public class PoliceAnimation : ActionAnimation
{
    public AudioSource KenAudio;
    public AudioClip PoliceClip;

    public GameObject policeman;
    public Transform policeSpawn;


    public void Update()
    {
        if (IsRunning)
        {
            if (!KenAudio.isPlaying)
            {
                IsRunning = false;
                Instantiate(policeman, policeSpawn.position, Quaternion.identity);
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = PoliceClip;
        KenAudio.Play();
    }
}
