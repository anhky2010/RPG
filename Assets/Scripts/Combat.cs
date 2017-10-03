using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat instance;
    CharacterStats characterStats;
    EnermyAnimation enermyAnimation;
    //public event System.Action OnAttack;
    public delegate void OnCombat();
    public OnCombat onCombat;
    public float delay = .0f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        enermyAnimation = GetComponent<EnermyAnimation>();
        characterStats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    bool isAttackingPlayer = false;

    public void Attack(CharacterStats targetStats)
    {



        if (attackCooldown <= 0f)
        {
            enermyAnimation.AttackAnimation();
            if (enermyAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("UD_infantry_07_attack_A"))
            {
                return;
            }

            if (isAttackingPlayer == false)
            {
                isAttackingPlayer = true;
                StartCoroutine(DoDamage(targetStats, delay));
                attackCooldown = 1f / attackSpeed;
            }
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float deleyTime)
    {
        yield return new WaitForSeconds(deleyTime);
        isAttackingPlayer = false;
        if (onCombat != null)
        {
            onCombat.Invoke();
        }
        stats.TakeDamage(characterStats.damage.GetFinalValue());

    }

}
