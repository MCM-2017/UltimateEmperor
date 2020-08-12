using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossStates : MonoBehaviour
{
    public Animator animator;
    public Transform[] PathPoints; // punkty do których boss się przemieszcza w fazie patrolowania
    public int patrolRange; // zakres "widzenia" bossa
    public float meleeRange;
    public Transform vision;
    public int stayAlarmed; // ilosc czasu "zaalarmowania" 
    public float meleeDamage; // ilość obrażeń zadawanych przez bossa;
    public float meeleDelay; // odstęp czasu pomiędzy atakami przez bossa

    public Transform chaseTarget; // obiekt do gonienia

    [HideInInspector] public alertState alertState;
    [HideInInspector] public attackState attackState;
    [HideInInspector] public chaseState chaseState;
    [HideInInspector] public patrolState patrolState;
    [HideInInspector] public FSM currentState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Vector3 lastPosition;

    private void Awake()
    {
        alertState = new alertState(this);
        attackState = new attackState(this);
        patrolState = new patrolState(this);
        chaseState = new chaseState(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
        currentState = patrolState;
    }
    void Update()
    {
        currentState.updateState(animator);
    }
    private void onTriggerEnter(Collision other)
    {
        currentState.onTriggerEnter(other, animator);
    }
    void ShootingFrom(Vector3 destination)
    {
        Debug.Log("Atakują");
        lastPosition = destination;
        currentState = alertState;
    }

}
