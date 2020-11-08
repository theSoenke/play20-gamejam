using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartThrowWindowAnimation : ActionAnimation
{
    public MeshRenderer KenMesh;
    public NavMeshAgent Ken;
    public AudioSource KenAudio;
    public AudioClip SmashClip;
    public Transform WindowPosition;


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = SmashClip;
        KenAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            if(!KenAudio.isPlaying) {
                Ken.enabled = false;  //disable pathfinding to prevent teleport back
                Ken.transform.position = WindowPosition.position;
                Ken.transform.rotation = WindowPosition.rotation;
                Ken.enabled = true;
                KenMesh.enabled = true;
                IsRunning = false;
            }
        }
    }
}

