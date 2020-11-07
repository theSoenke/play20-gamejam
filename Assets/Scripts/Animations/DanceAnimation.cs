using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DanceAnimation : ActionAnimation
{
    private Transform[] _dancePoints;
    private Transform _danceTargetPoint;
    private bool _isAtTarget;
    private float _currentDanceTime;

    public KenVisualsManager Ken;
    public Transform DancePoints;
    public float DanceTime = 2;

    void Awake()
    {
        if (!DancePoints) DancePoints = transform;
        _dancePoints = Enumerable.Range(0, DancePoints.childCount).Select(i => DancePoints.GetChild(i)).ToArray();
    }

    void Update()
    {
        if (IsRunning)
        {
            if (!_isAtTarget && Vector3.Distance(Ken.transform.position, _danceTargetPoint.position) < 0.2)
            {
                _isAtTarget = true;
                _currentDanceTime = 0;
            }
            if (_isAtTarget)
            {
                if (_currentDanceTime > DanceTime)
                {
                    IsRunning = false;
                    if (Ken.IsDancing) Ken.SetDanceState(false);
                    //Ken.IsDancing = false;
                } 
                else
                {
                    // Do DanceMove
                    if (!Ken.IsDancing) Ken.SetDanceState(true);
                    _currentDanceTime += Time.deltaTime;
                }
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _isAtTarget = false;
        _danceTargetPoint = _dancePoints[Random.Range(0, _dancePoints.Length)];
        if (!(Vector3.Distance(Ken.transform.position, _danceTargetPoint.position) < 0.2))
        {
            Ken.Nav.SetDestination(_danceTargetPoint.position);
        }
    }
}
