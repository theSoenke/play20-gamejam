using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrinkAnimation : ActionAnimation
{
    public NavMeshAgent Ken;
    public Transform DrinkTarget;

    public void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnPhaseChanged;
    }

    public void Update()
    {
        if (IsRunning)
        {
            if(Vector3.Distance(Ken.transform.position, DrinkTarget.position) < 0.2) {
                Ken.enabled = false;
                IsRunning = false;
            }
        }
    }


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        Ken.SetDestination(DrinkTarget.position);
        Ken.enabled = true;
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
