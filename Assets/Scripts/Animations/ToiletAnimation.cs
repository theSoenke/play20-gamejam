using UnityEngine;
using UnityEngine.AI;

public class ToiletAnimation : ActionAnimation
{
    public NavMeshAgent Ken;
    public Transform ToiletTarget;
    public AudioSource KenAudio;
    public AudioClip ToiletClip;

    private bool _isAtTarget = false;

    public void Start()
    {
        GameStateManager.Instance.GamePhaseChanged += OnPhaseChanged;
    }


    public void Update()
    {
        if (IsRunning)
        {
            if (!_isAtTarget && Vector3.Distance(Ken.transform.position, ToiletTarget.position) < 0.2)
            {
                _isAtTarget = true;
                // Ken.enabled = false;
                KenAudio.clip = ToiletClip;
                KenAudio.Play();
            }
            if (_isAtTarget && !KenAudio.isPlaying)
            {
                IsRunning = false;
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _isAtTarget = false;
        if (!(Vector3.Distance(Ken.transform.position, ToiletTarget.position) < 0.2))
        {
            Ken.SetDestination(ToiletTarget.position);
            // Ken.enabled = true;
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
