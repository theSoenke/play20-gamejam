using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TalkToGuestAnimation : ActionAnimation
{
    private Transform _targetPoint;
    private bool _isAtTarget;

    public PartyMenschen Menschen;
    public KenVisualsManager Ken;
    public AudioSource KenAudio;
    public AudioClip MumbleClip;


    void Update()
    {
        if (IsRunning)
        {
            if (!_isAtTarget && Vector3.Distance(Ken.transform.position, _targetPoint.position) < 0.2)
            {
                _isAtTarget = true;
                Ken.enabled = false;
            }
            if (_isAtTarget)
            {
                if (!KenAudio.isPlaying)
                {
                    IsRunning = false;
                    Ken.enabled = true;
                    //Stop
                }
                else
                {
                    //Do Talk      
                    Ken.transform.rotation = Quaternion.Lerp(Ken.transform.rotation, _targetPoint.rotation, Time.deltaTime * 5f);
                    KenAudio.clip = MumbleClip;
                    KenAudio.Play();
                }
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _isAtTarget = false;
        _targetPoint = Menschen.GetRandomTransform();
        if (!(Vector3.Distance(Ken.transform.position, _targetPoint.position) < 0.2))
        {
            Ken.Nav.SetDestination(_targetPoint.position);
        }
    }
}
