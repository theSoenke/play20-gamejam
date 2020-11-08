using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrinkAnimation : ActionAnimation
{
    public NavMeshAgent Ken;
    public Transform DrinkTarget;
    public AudioSource KenAudio;
    public AudioClip DrinkBeerClip;

    private bool _isAtTarget = false;

    public void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnPhaseChanged;
    }

    public void Update()
    {
        if (IsRunning)
        {
            if(!_isAtTarget && Vector3.Distance(Ken.transform.position, DrinkTarget.position) < 0.2) {
                _isAtTarget = true;
                KenAudio.clip = DrinkBeerClip;
                KenAudio.Play();
                Ken.enabled = false;
            }
            if (_isAtTarget) {
                if (!KenAudio.isPlaying)
                {
                    Ken.enabled = true;
                    IsRunning = false;
                }
                else
                {
                    Ken.transform.rotation = Quaternion.Lerp(Ken.transform.rotation, DrinkTarget.rotation, Time.deltaTime * 5f);
                }
            }
        }
    }


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _isAtTarget = false;
        if(! (Vector3.Distance(Ken.transform.position, DrinkTarget.position) < 0.2)) {
            Ken.SetDestination(DrinkTarget.position);
        }
    }

    private void OnPhaseChanged(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.PhaseComplete:
                Reset();
                break;
            default:
                break;
        }
    }

    private void Reset()
    {

    }
}
