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
    public List<GameObject> flashWord;

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
        ChangeDefaultAnimation();
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("param_speedRun", speed);
    }

    public void AttackAnimation(int _numberEffect)
    {
        animator.SetTrigger("param_1HAttack");
        Instantiate(flashWord[_numberEffect], PlayerManager.instance.player.transform.position, PlayerManager.instance.player.transform.rotation);
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
