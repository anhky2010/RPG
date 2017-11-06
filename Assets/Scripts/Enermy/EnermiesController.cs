using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnermiesController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    private Vector3 startPosition;
    private Quaternion startQuaternion;
    EnermyScript enemy;
    Combat combat;
    EnermyStats enermyStats;
    // Use this for initializations
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<Combat>();
        enemy = GetComponent<EnermyScript>();
        enermyStats = GetComponent<EnermyStats>();
        startPosition = gameObject.transform.position;
        startQuaternion = gameObject.transform.rotation;
        agent.speed = enermyStats.speed.GetFinalValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (enermyStats.alive == false) return;
        AutoAttack();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRatation, Time.deltaTime * 5f);
    }


    public void Attack()
    {
        EnermyAnimation eAni = GetComponent<EnermyAnimation>();
        CharacterStats targetStats = target.GetComponent<PlayerStats>();
        if (enermyStats.curDCAtt > 0) return;

        if (!eAni.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (targetStats == null) return;
            float distance = Vector3.Distance(target.transform.position, transform.position);
            //set khoang cach dung nhan vat ung voi attack range 
            agent.stoppingDistance = enermyStats.attackRange.GetFinalValue();
            if (distance < enermyStats.attackRange.GetFinalValue())
            {
                eAni.AttackAnimation(enermyStats.attackSpeed.GetFinalValue());
                combat.Attack(targetStats);
                agent.stoppingDistance = enermyStats.attackRange.GetFinalValue();
                // Debug.Log("Player tan cong");
            }
        }
    }

    public void AutoAttack()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
            CharacterStats targetStats = target.GetComponent<PlayerStats>();
            if (distance < enermyStats.attackRange.GetFinalValue())
            {
                if (targetStats != null)
                {
                    Attack(); //tan cong nguoi choi
                }
            }
        }
        else
        {
            agent.SetDestination(startPosition);
            Vector3 precision = new Vector3(0, 0, 0);
            if (Vector3.Distance(gameObject.transform.position, startPosition) < 1)
            {               
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, startQuaternion, Time.deltaTime * 5f);
            }

        }



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
