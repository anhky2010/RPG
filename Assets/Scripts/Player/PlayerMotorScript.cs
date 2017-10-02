using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotorScript : MonoBehaviour {

    Transform target;
    NavMeshAgent agent; 
	void Start () {         
        agent = GetComponent<NavMeshAgent>();
	} 
    private void Update()
    {
        if (target!=null)
        {           
            agent.SetDestination(target.position);            
            FaceTarget();
        }
    }
    //di den 1 vi tri
    public void MoveToPoint(Vector3 point)
    {
        agent.speed = PlayerStats.instance_player.speed.GetFinalValue();
        agent.SetDestination(point);
    }

    //theo sau 1 vat the
    public void FollowTarget(Intertactable newTarger)
    {
        agent.stoppingDistance = newTarger.radius *.5f;
        agent.updateRotation = false;
        target = newTarger.interactableTranform; 
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;    
        agent.updateRotation = true; 
        target = null;
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
