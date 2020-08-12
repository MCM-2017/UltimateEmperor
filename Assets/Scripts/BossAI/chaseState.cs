using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class chaseState : FSM
{
    private BossStates b;
    public chaseState(BossStates b)
    {
        this.b = b;
    }

    public void attackState(Animator animator)
    {
        b.currentState = b.attackState;
    }

    public void onTriggerEnter(Collision enemy, Animator animator)
    {
        throw new System.NotImplementedException();
    }

    public void patrolState(Animator animator)
    {
        Debug.Log("Impossible");
    }

    public void updateState(Animator animator)
    {
        Watch(animator);
        Follow(animator);
    }
    void FSM.chaseState(Animator animator)
    {
        b.navMeshAgent.destination = b.chaseTarget.position;
        b.navMeshAgent.isStopped = false;
        if (b.navMeshAgent.remainingDistance <= b.meleeRange)
        {
            b.navMeshAgent.isStopped = true;
            animator.SetFloat("distance", 0.1f);
            attackState(animator);
        }
    }
    void Watch(Animator animator)
    {
        float distance = Vector3.Distance(b.transform.position, b.chaseTarget.transform.position);
        if (distance > b.patrolRange)
        {
            b.navMeshAgent.speed = 1;
            animator.SetBool("isInRange", true);
            animator.SetBool("enemyMissing", true);
            alertState(animator);
        }
        else
        {
            b.lastPosition = b.chaseTarget.position;
        }
    }

    private void alertState(Animator animator)
    {
        b.currentState = b.alertState;
    }

    void Follow(Animator animator)
    {
        b.navMeshAgent.speed = 2;
        float distance = Vector3.Distance(b.transform.position, b.chaseTarget.transform.position);
        b.navMeshAgent.destination = b.chaseTarget.position;
        b.navMeshAgent.isStopped = false;
        if (distance <= b.meleeRange)
        {
            Debug.Log("ATAKUJEMY");
            animator.SetFloat("distance", 0.1f);
            attackState(animator);
        }
    }
}
