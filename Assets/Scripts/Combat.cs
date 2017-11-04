using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public static Combat instance;
    CharacterStats characterStats; 
    //public event System.Action OnAttack;
    public delegate void OnCombat();
    public OnCombat onCombat;
    public float delay = .0f; 
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
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

        if (_stats != null) _stats.TakeDamage(_dmg);


        if (onCombat != null)
        {
            onCombat.Invoke();
        }

    }




}
