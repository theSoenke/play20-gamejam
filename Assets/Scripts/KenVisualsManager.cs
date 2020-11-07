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

    public bool IsDancing;

    public void Update()
    {        
        Animator.SetFloat("WalkSpeed", Nav.velocity.magnitude * AnimationSpeedFactor);
        Animator.SetBool("IsWalking", Nav.enabled);
        //if (Animator.GetBool("IsDancing") != IsDancing)
        //{
        //    Animator.SetBool("IsDancing", IsDancing);
        //}
    }

    public void SetDanceState(bool dance)
    {
        IsDancing = dance;
        if (dance)
        {
            Animator.SetTrigger("Dance");
        } 
        else
        {
            Animator.SetTrigger("StopDance");
        }
    }
}
