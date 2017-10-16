using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{
    int handWeapon;
    NavMeshAgent agent;
    public Animator animator;
    public List<GameObject> flashWord;

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

    public void AttackAnimation(int _numberEffect)
    {
        animator.SetTrigger("param_1HAttack");
        Instantiate(flashWord[_numberEffect], PlayerManager.instance.player.transform.position, PlayerManager.instance.player.transform.rotation);
    }
    void ChangeDefaultAnimation()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            handWeapon = 2;
            animator.SetInteger("param_Hand", handWeapon);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            handWeapon = 1;
            animator.SetInteger("param_Hand", handWeapon);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AttackAnimation(0);
        }

    }
}
