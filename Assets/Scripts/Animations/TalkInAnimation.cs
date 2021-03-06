﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TalkInAnimation : ActionAnimation
{
    public MeshRenderer KenMesh;
    public NavMeshAgent Ken;
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
                Ken.enabled = false; //disable pathfinding to prevent teleport back
                Ken.transform.position = DoorPosition.position;
                Ken.transform.rotation = DoorPosition.rotation;
                Ken.enabled = true;
                KenMesh.enabled = true;
                IsRunning = false;
            }
        }
    }
}

