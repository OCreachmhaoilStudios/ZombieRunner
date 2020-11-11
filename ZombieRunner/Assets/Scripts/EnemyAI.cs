using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float chaseRange = 10f;
	[SerializeField] float maxChaseRange = 30f;
	[SerializeField] float attackRange = 1f;
	[SerializeField] float turnSpeed = 5f;
	
	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;
	bool isProvoked = false;
	
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
	    distanceToTarget = Vector3.Distance(target.position, transform.position);
		if(isProvoked)
		{
			EngageTarget();
		}
		else if(distanceToTarget <= chaseRange)
		{
			isProvoked = true;
		}
    }
    
    void OnDrawGizmosSelected()
    {
	    Gizmos.color = Color.red;
	    Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    
   private void EngageTarget()
    {
	    
	    FaceTarget();
	    
	    if(distanceToTarget <= navMeshAgent.stoppingDistance)
	    {
		    AttackTarget();
	    }
	    else if(distanceToTarget >= navMeshAgent.stoppingDistance)
	    {
		    ChaseTarget();
	    }
	    
	    // distanceToTarget <= attackRange ? AttackTarget() : ChaseTarget();
    }
    
    private void ChaseTarget()
    {
	    GetComponent<Animator>().SetBool("attack", false);
	    GetComponent<Animator>().SetTrigger("move");
	    navMeshAgent.SetDestination(target.position);
    }
    
	private void AttackTarget()
    {
	    GetComponent<Animator>().SetBool("attack", true);
    }
    
    private void FaceTarget()
    {
	   Vector3 direction = (target.position - transform.position).normalized;
	   Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
	   transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); 
    }
    
    public void OnDamageTaken()
    {
	    this.isProvoked = true;
    }
}
