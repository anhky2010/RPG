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
        startPosition = transform.position;

        agent.speed = enermyStats.speed.GetFinalValue();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
            CharacterStats targetStats = target.GetComponent<PlayerStats>();
            if (distance < enemy.radius)
            {
                if (targetStats != null)
                {
                    combat.Attack(targetStats); //tan cong nguoi choi
                }
            }
        }
        else agent.SetDestination(startPosition);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRatation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
