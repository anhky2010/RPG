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
    [SerializeField] bool isPlayer = false;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        if (!isPlayer)
        {
            enermyAnimation = GetComponent<EnermyAnimation>();
        }
        characterStats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        if (characterStats.curDCAtt > -1)
        {
            characterStats.curDCAtt -= Time.deltaTime;
        }
    }


    public void Attack(CharacterStats targetStats)
    {
        if (characterStats.curDCAtt <= 0f)
        {
            if (isPlayer == false)
            {
                if (enermyAnimation != null)
                {
                    //if (enermyAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("UD_infantry_07_attack_A"))
                    //    return;
                    enermyAnimation.AttackAnimation();
                }
            }
            int _dmg = characterStats.damage.GetFinalValue();
            StartCoroutine(DoDamage(targetStats, delay, _dmg));
            characterStats.curDCAtt = 1f / characterStats.attackSpeed.GetFinalValue(); ;
        }
    }
    public void SkillAttack(CharacterStats _targetStats, float _delay, int _dmg)
    {
        StartCoroutine(DoDamage(_targetStats, _delay, _dmg));

    }
    IEnumerator DoDamage(CharacterStats _stats, float _delayTime, int _dmg)
    {
        yield return new WaitForSeconds(_delayTime);
        if (onCombat != null)
        {
            onCombat.Invoke();
        }
        _stats.TakeDamage(_dmg);
    }



}
