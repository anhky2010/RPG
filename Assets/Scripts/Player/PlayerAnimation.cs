using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;
    int handWeapon;
    NavMeshAgent agent;
    public Animator animator;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        AnimationChecker();
        ChangeDefaultAnimation();

        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("param_speedRun", speed);
    }
    void AnimationChecker()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Cast_Spell_1")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Cast_Spell_2")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Cast_Spell_3")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Cast_Spell_4")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("Cast_Spell_5"))
        {
            agent.speed = 0f;
        }
    }
    public void AttackAnimation(int _speedAtt)
    {
        animator.SetTrigger("param_1HAttack");
        animator.speed = _speedAtt;
        Transform pTransform = PlayerManager.instance.player.transform;
        //  Debug.Log(animator.speed);
    }
    public void DeathAnimation()
    {
        animator.Play("Death");
    }
    public void CastSpellAnimation(int _paramValue)
    {
        switch (_paramValue)
        {
            case 1:
                animator.SetTrigger("param_CastSpell_1");
                break;
            case 2:
                animator.SetTrigger("param_CastSpell_2");
                break;
            case 3:
                animator.SetTrigger("param_CastSpell_3");
                break;
            case 4:
                animator.SetTrigger("param_CastSpell_4");
                break;
            case 5:
                animator.SetTrigger("param_CastSpell_5");
                break;
            default:
                break;
        }
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
    }
}
