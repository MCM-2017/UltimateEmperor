using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class patrolState : FSM
{
    private BossStates b;
    int nextWayPoint = 0; //nastepny punkt do patrolowania
    public patrolState(BossStates b)
    {
        this.b = b;
    }
    public void attackState(Animator animator)
    {
        b.navMeshAgent.speed = 2;
        b.currentState = b.attackState;
    }

    public void chaseState(Animator animator)
    {
        
        b.currentState = b.chaseState;
    }

    public void onTriggerEnter(Collision enemy, Animator animator)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            // alertState();
            Debug.Log("Widzę Go!");
        }
    }

    public void updateState(Animator animator)
    {
        Watch(animator);
        Patrol();
    }

    void FSM.patrolState(Animator animator)
    {
        Debug.LogError("Patrolling now");
    }
    void Watch(Animator animator)
    {
        float distance = Vector3.Distance(b.transform.position, b.chaseTarget.transform.position);
        if (distance <= b.patrolRange)
        {
            // Debug.Log("MAM CIE");
            animator.SetBool("enemyMissing", false);
            animator.SetBool("isInRange", true);
            chaseState(animator);
        }
        /*
        RaycastHit hit;
        if(Physics.Raycast(z.transform.position,z.transform.TransformDirection(Vector3.back),out hit,Mathf.Infinity))
        {
            Debug.Log("XD");
            if(hit.collider.CompareTag("Player"))
                {
                Debug.Log("MAM WROGA");
                z.chaseTarget = hit.transform;
                //chaseState();
            }
        }*/

    }
    void Patrol()
    {
        b.navMeshAgent.speed = 1;
        b.navMeshAgent.destination = b.PathPoints[nextWayPoint].position;
        b.navMeshAgent.isStopped = false;
        if (b.navMeshAgent.remainingDistance <= b.navMeshAgent.stoppingDistance)
        {
           // Debug.Log("Idę Do następnego");
            nextWayPoint = (nextWayPoint + 1) % b.PathPoints.Length;
        }
    }
    void Start()
    {
    }
}