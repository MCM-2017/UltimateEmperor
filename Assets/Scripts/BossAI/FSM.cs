using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FSM
{
    
    void updateState(Animator animator);

    void onTriggerEnter(Collision enemy, Animator animator);

    void patrolState(Animator animator);

    void attackState(Animator animator);

    void chaseState(Animator animator);
}
