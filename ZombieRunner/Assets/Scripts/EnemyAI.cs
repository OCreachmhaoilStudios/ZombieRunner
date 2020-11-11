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
	    // if in attack range, attack
	    
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
	    Debug.Log(name + " is attacking " + target.name+ "!");
    }
}
