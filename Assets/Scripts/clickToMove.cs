using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;

    private NavMeshAgent mNavMeshAgent;

    private bool mWalk = false;
    private bool stoppingWalk = false;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
            }
        }
        if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {   
            mWalk = false;
            stoppingWalk = true;
        }
        else
        {
            mWalk = true;
        }
        mAnimator.SetBool("walk", mWalk);
    }
}
