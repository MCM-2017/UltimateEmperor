using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public Boss boss;
    public float meleeRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("meleeAttackHand");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("kickAttack");
        }
    }

    void MeleeAttack()
    {
        float distance = Vector3.Distance(this.transform.position, boss.transform.position);
        if(distance <= meleeRange)
            boss.meleeAttackhit(Random.Range(8,15));
    }
}
