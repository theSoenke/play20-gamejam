using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxen : MonoBehaviour
{
    public AudioSource MusicSource;
    public Animator Animator;

    private bool _stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        Animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MusicSource.isPlaying &! _stopped)
        {
            Animator.SetTrigger("StopPulse");
            _stopped = true;
        }
        if (_stopped && MusicSource.isPlaying)
        {
            _stopped = false;
            Animator.playbackTime = 0;
            Animator.SetTrigger("StartPulse");
        }
    }
}
