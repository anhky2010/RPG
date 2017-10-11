using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{
    public int handWeapon;
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
        ChangeDefaultAnimation();
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("param_speedRun", speed);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("param_1HAttack");
    }
    void ChangeDefaultAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handWeapon = 2;
            animator.SetInteger("param_Hand", handWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handWeapon = 1;
            animator.SetInteger("param_Hand", handWeapon);
        }

    }
}
