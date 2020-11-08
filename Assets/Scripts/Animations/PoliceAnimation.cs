using UnityEngine;
using UnityEngine.AI;

public class PoliceAnimation : ActionAnimation
{
    public AudioSource KenAudio;
    public AudioClip PoliceClip;
    public Transform Ken;

    public GameObject policeman;
    public Transform policeSpawn;

    private NavMeshAgent navMeshAgent;
    private Animator animator;


    public void Update()
    {
        if (IsRunning)
        {
            if (!KenAudio.isPlaying)
            {
                if(navMeshAgent == null)
                {
                    var policeGo = Instantiate(policeman, policeSpawn.position, Quaternion.identity);
                    navMeshAgent = policeGo.GetComponent<NavMeshAgent>();
                    navMeshAgent.SetDestination(Ken.position);
                    animator = policeGo.GetComponentInChildren<Animator>();
                }

                if(Vector3.Distance(Ken.transform.position, navMeshAgent.transform.position) < 2f)
                {
                    IsRunning = false;
                }        
            }
        }

        if(animator != null)
        {
            animator.SetFloat("WalkSpeed", navMeshAgent.velocity.magnitude);
            animator.SetBool("IsWalking", navMeshAgent.enabled);
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = PoliceClip;
        KenAudio.Play();
    }
}
