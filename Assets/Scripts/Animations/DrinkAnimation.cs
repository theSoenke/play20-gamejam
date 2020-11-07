using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkAnimation : ActionAnimation
{
    public Transform Ken;
    public Transform DrinkTarget;
    public float AnimationDuration = 2;

    private Vector3 _kenStartPosition;
    private float _animationStartTs;

    public void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnPhaseChanged;
    }

    public void Update()
    {
        if (IsRunning)
        {
            Ken.rotation = DrinkTarget.rotation;
            var animationProgress = Mathf.Min((Time.time - _animationStartTs) / AnimationDuration, 1);
            Ken.position = Vector3.Lerp(_kenStartPosition, DrinkTarget.position, animationProgress);
            if(animationProgress == 1) {
                IsRunning = false;
            }
        }
    }


    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _kenStartPosition = Ken.position;
        _animationStartTs = Time.time;
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
