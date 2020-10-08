using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;
    protected CharacterCombat combat;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        combat.OnAttack += OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
        if (speed > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
        animator.SetBool("InCombat", combat.InCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("AttackTrigger");
    }

    public void DieAnimation()
    {
        animator.SetTrigger("DieTrigger");
    }
}
