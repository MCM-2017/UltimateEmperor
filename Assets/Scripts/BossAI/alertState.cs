using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertState : FSM
{
    private BossStates b;
    float timer = 0;
    public alertState(BossStates b)
    {
        this.b = b;
    }
    public void attackState(Animator animator)
    {
        Debug.Log("Nie mogę przejść z alert do attack state");
    }
    public void chaseState(Animator animator)
    {
        b.currentState = b.chaseState;
    }
    public void onTriggerEnter(Collision enemy, Animator animator)
    {
        Debug.Log("UTKNALEM");
    }
    public void patrolState(Animator animator)
    {
        b.currentState = b.patrolState;
    }
    public void updateState(Animator animator)
    {
        Find(animator);
        Watch(animator);
        if (b.navMeshAgent.remainingDistance <= b.navMeshAgent.stoppingDistance)
        {
            
            LookAround(animator);
        }
    }
    private void Find(Animator animator)
    {
        b.navMeshAgent.destination = b.lastPosition;
        b.navMeshAgent.isStopped = false;
    }
    void Watch(Animator animator)
    {
        float distance = Vector3.Distance(b.transform.position, b.chaseTarget.transform.position);
        if (distance <= b.patrolRange)
        {
            animator.SetBool("enemyMissing", false);
            chaseState(animator);
        }
    }
    void LookAround(Animator animator)
    {
        b.navMeshAgent.speed = 1;
        animator.SetBool("isLookingAround", true);
        timer += Time.deltaTime;
        if (timer >= b.stayAlarmed)
        {
            timer = 0;
            animator.SetBool("isInRange", false);
            animator.SetBool("isLookingAround", false);
            patrolState(animator);
        }
    }
}
