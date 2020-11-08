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
                    // navMeshAgent.SetDestination(Ken.position);
                }

                if(Vector3.Distance(Ken.transform.position, navMeshAgent.transform.position) < 0.2)
                {
                    IsRunning = false;
                }        
            }
        }
    }

    public override void RunAnimation(GameState state)
    {
        IsRunning = true;
        KenAudio.clip = PoliceClip;
        KenAudio.Play();
    }
}
