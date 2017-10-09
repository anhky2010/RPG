using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnermyAnimation : MonoBehaviour
{


    public Animator animator;
    public bool isAttack = false;
    private NavMeshAgent agent;
    EnermyStats enermyStats;
    private void Start()
    {
        enermyStats = GetComponent<EnermyStats>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Run();
    }

    private void Run()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedEnemy", speed);

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("UD_infantry_07_attack_A"))
        { agent.speed = 0.1F; }
        else agent.speed = enermyStats.speed.GetFinalValue();
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("EnermyAttack");
        Debug.Log("Animation tan cong!");
    }


}
