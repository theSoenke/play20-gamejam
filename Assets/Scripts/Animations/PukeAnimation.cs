using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PukeAnimation : ActionAnimation
{

    public NavMeshAgent Ken;
    public Transform PukeTarget;
    public AudioSource KenAudio;
    public AudioClip PukeClip;

    private bool _isAtTarget = false;

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        _isAtTarget = false;
        if(! (Vector3.Distance(Ken.transform.position, PukeTarget.position) < 0.2)) {
            Ken.SetDestination(PukeTarget.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            if(!_isAtTarget && Vector3.Distance(Ken.transform.position, PukeTarget.position) < 0.2) {
                _isAtTarget = true;
                KenAudio.clip = PukeClip;
                KenAudio.Play();
            }
            if(_isAtTarget && !KenAudio.isPlaying) {
                IsRunning = false;
            }
        }
    }
}
