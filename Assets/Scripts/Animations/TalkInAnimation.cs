using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TalkInAnimation : ActionAnimation
{
    public MeshRenderer KenMesh;
    public Transform Ken;
    public AudioSource KenAudio;
    public AudioClip KnockClip;
    public Transform DoorPosition;


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = KnockClip;
        KenAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            if(!KenAudio.isPlaying) {
                Ken.transform.position = DoorPosition.position;
                Ken.transform.rotation = DoorPosition.rotation;
                KenMesh.enabled = true;
                IsRunning = false;
            }
        }
    }
}

