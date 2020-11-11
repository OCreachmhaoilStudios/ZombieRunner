using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] float hitPoints = 100;
	
	// Create public method to reduce hitPoints by amount of damage specified by the weapon
	
	public void TakeDamage(float damage)
	{
		BroadcastMessage("OnDamageTaken");
		this.hitPoints -= damage;
		if(this.hitPoints <= 0) { Destroy(gameObject); }
		return;
	}
	
}
