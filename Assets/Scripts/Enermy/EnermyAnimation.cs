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

    protected string runningAniName;
    protected string paramDeath;
    protected string paramAttack;
    public virtual void Start()
    {
        enermyStats = GetComponent<EnermyStats>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Run();
    }
    protected  void Run()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        CheckRunningAnimation();
        animator.SetFloat("SpeedEnemy", speed);
    }
    //"UD_infantry_07_attack_A"
    protected void CheckRunningAnimation()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName(runningAniName))
        { agent.speed = 0.0F; }
        else agent.speed = enermyStats.speed.GetFinalValue();
    }
    //EnermyAttack
    public void AttackAnimation(int _speedAtt)
    {
        animator.SetTrigger(paramAttack);
        animator.speed = _speedAtt;
    }
    //Death_2
    public void DeathAnimation()
    {
        animator.Play(paramDeath);
    }



}
