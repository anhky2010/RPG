using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{

    const float locaomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("param_speedRun", speed);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("param_1HAttack");
    }
}
