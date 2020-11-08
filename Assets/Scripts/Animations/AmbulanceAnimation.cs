using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmbulanceAnimation : ActionAnimation
{
    public GameObject Ambulance;
    public Transform KenAmbulanceTransform;
    public NavMeshAgent Ken;
    public AudioSource KenAudio;
    public AudioClip AmbulanceClip;
    public Transform DoorPosition;
    public float AnimationDuration;


    private Vector3 _ambulanceStart;
    private float _startTime;


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = AmbulanceClip;
        KenAudio.Play();
        Ken.enabled = false;
        Ambulance.SetActive(true);
        Ken.transform.parent = KenAmbulanceTransform;
        Ken.transform.localPosition = Vector3.zero;
        Ken.transform.localRotation = Quaternion.identity;
        _ambulanceStart = Ambulance.transform.position;
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            var animationProgress = (Time.time - _startTime) / AnimationDuration;
            Ambulance.transform.position = Vector3.Lerp(_ambulanceStart, DoorPosition.position, animationProgress);
            if(Vector3.Distance(DoorPosition.position, Ambulance.transform.position) < 0.3) {
                Ambulance.SetActive(false);
                KenAudio.Stop();
                IsRunning = false;
            }
        }
    }
}

