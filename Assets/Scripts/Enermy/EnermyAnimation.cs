using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnermyAnimation : MonoBehaviour
{

    NavMeshAgent agent;
    float tempSpeed;
    public Animator animator;
    public bool isAttack = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        tempSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    public void Run()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedEnemy", speed);

        WaitForAnimator("UD_infantry_07_attack_A");
    }
    public void WaitForAnimator(string animation_name)
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName(animation_name))
        {
            agent.speed = 0;

        }
        else agent.speed = tempSpeed;

    }
    public void AttackAnimation()
    {
        animator.SetTrigger("EnermyAttack");
        Debug.Log("Animation tan cong!");
    }


}
