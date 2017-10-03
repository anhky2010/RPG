using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    public static Combat instance;
    CharacterStats characterStats;
    public delegate void OnCombat();
    public OnCombat onCombat;
    public float delay = .0f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0;
    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        instance = this;
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            if (isAttackingPlayer == false)
            {
                isAttackingPlayer = true;
                StartCoroutine(DoDamage(targetStats, delay));
                attackCooldown = 1f / attackSpeed;
            }
        }

    }
    bool isAttackingPlayer = false;
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
