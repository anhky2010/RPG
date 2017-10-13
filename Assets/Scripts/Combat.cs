using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat instance;
    CharacterStats characterStats;
    EnermyAnimation enermyAnimation;
    PlayerAnimation playerAnimation;
    //public event System.Action OnAttack;
    public delegate void OnCombat();
    public OnCombat onCombat;
    public float delay = .0f;
    public float attackSpeed = 1f;
    private float attackCooldown = 0;
    [SerializeField] bool isPlayer = false;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (isPlayer)
        {
            playerAnimation = GetComponent<PlayerAnimation>();
        }
        if (!isPlayer)
        {
            enermyAnimation = GetComponent<EnermyAnimation>();
        }
        characterStats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }


    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            if (isPlayer == false)
            {
                if (enermyAnimation != null)
                {
                    if (enermyAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("UD_infantry_07_attack_A"))
                        return;
                    enermyAnimation.AttackAnimation();
                }
            }
            if (isPlayer == true)
            {
                if (playerAnimation != null)
                {
                    if (playerAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("1HAttack"))
                        return;
                    playerAnimation.AttackAnimation(0);
                }
            }
            StartCoroutine(DoDamage(targetStats, delay));
            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float deleyTime)
    {
        yield return new WaitForSeconds(deleyTime);
        if (onCombat != null)
        {
            onCombat.Invoke();
        }
        stats.TakeDamage(characterStats.damage.GetFinalValue());

    }

}
