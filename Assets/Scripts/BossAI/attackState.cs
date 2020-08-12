using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class attackState : FSM
{
    private BossStates b;
    float timer = 0;
    public attackState(BossStates b)
    {
        this.b = b;
    }
    public void chaseState(Animator animator)
    {
        b.currentState = b.chaseState;
    }
    public void onTriggerEnter(Collision enemy, Animator animator)
    {
        throw new System.NotImplementedException();
    }
    public void patrolState(Animator animator)
    {
        Debug.Log("Nie ma możliwości przejścia stanu Attack--> patrol");
    }
    public void updateState(Animator animator)
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(b.chaseTarget.transform.position, b.transform.position);
        //Debug.Log("Dystans:" + distance.ToString());
        if (distance > b.meleeRange)
        {
            animator.SetFloat("distance", 11f);
            chaseState(animator);
            b.navMeshAgent.isStopped = false;
        }
        Watch(animator);
        if (distance <= b.meleeRange)
        {
            //b.chaseTarget.SendMessage("TakeDamage", b.meleeDamage, SendMessageOptions.DontRequireReceiver);

            animator.SetFloat("distance", 0.1f);
            b.navMeshAgent.isStopped = true;
        }
    }
    void FSM.attackState(Animator animator)
    {
        Debug.Log("Error"); // no logic
    }
    void Watch(Animator animator)
    {
        float distance = Vector3.Distance(b.transform.position, b.chaseTarget.transform.position);
        if (distance > b.patrolRange)
        {
            animator.SetFloat("distance", 12f);
           // GlobalPlayerControl.instance.animator.SetBool("enemyMissing", true);
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

}
