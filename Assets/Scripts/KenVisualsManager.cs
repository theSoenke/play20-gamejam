using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KenVisualsManager : MonoBehaviour
{
    public Animator Animator;
    public NavMeshAgent Nav;

    [Range(0,1)]
    public float AnimationSpeedFactor;

    public void Update()
    {
        Animator.SetFloat("WalkSpeed", Nav.velocity.magnitude * AnimationSpeedFactor );
        Animator.SetBool("IsWalking", Nav.enabled);
    }
}
