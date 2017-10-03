using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnermyAnimation : MonoBehaviour
{

    const float locaomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    float tempSpeed;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
       // Combat.instance.onCombat += Attack;
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
    private void WaitForAnimator(string animation_name)
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName(animation_name))
        {
            agent.speed = 0;
        }
        else agent.speed = tempSpeed;

    }
    public void Attack()
    {
        animator.SetTrigger("EnermyAttack");
        //Debug.Log("Animation tan cong!");
    }
}
